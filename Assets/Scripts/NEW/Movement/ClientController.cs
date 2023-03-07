using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;


public class ClientController : PlayerControllerBehavior
{
    /*
     * Allows for Client Player Movement, removed if not the client
     */

    public enum EMovementModes
    {
        Ground = 0,
        Flying = 1,
    }

    #region Private
    private Rigidbody rb;
    private Camera clientCamera;
    private ServerInformation serverInformation;
    private EMovementModes currentState = EMovementModes.Ground;
    
    [SerializeField, Tooltip("The MainPlayerController responsible for Client movement")]
    private MainPlayerController inputController;
    public MainPlayerController InputController
    {
        get { return inputController; }
    }

    [SerializeField, Tooltip("The UI Manager responsible for Client UI elements")]
    private UIManager ui_Manager;
    public UIManager UI_Manager
    { 
        get { return ui_Manager; } 
    }
    #endregion

    [Space]
    
    #region Protected Vars
    [SerializeField, Tooltip("How fast the Altitude changes when in Flight Mode")]
    protected float altitudeChangeSpeed = 1.0f;

    [SerializeField, Tooltip("The maximum speed the player can move")]
    protected float maxMoveSpeed = 10.0f;

    [SerializeField, Tooltip("How fast the player accelerates")]
    protected float moveSpeedAcceleration = 10.0f;

    [SerializeField, Tooltip("The force the player will jump at")]
    protected float jumpForce = 10.0f;

    [SerializeField, Tooltip("The Vector we wish to move the player in")]
    protected Vector3 movementDirection = Vector3.zero;

    [SerializeField, Tooltip("The speed the player will rotate towards the movement direction"), Range(0,1)]
    protected float rotationSpeed = 0.5f;
    #endregion
    [SerializeField]
    private bool bIsGrounded = true;

    private Quaternion playerRotation;

    /// <summary>
    /// Called when the Network has just been opened up
    /// </summary>
    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsOwner) //Do not continue if not the Owner, will stop any "Object Reference not found" errors
            return;

        serverInformation = GetComponent<ServerInformation>();

        rb = GetComponent<Rigidbody>();

        if (inputController == null) //Since not Monobehaviour, instanciate in memory if null
            inputController = new MainPlayerController();

        ui_Manager = GetComponent<UIManager>();
        ui_Manager.clientController = this;
        clientCamera = GetComponent<Camera>();

        #region Controller Setup
        inputController.Constant.Enable();
        
        //Forward Movement Performed and Cancelled
        inputController.Movement.Forward.performed += context => ForwardMovement(context);
        inputController.Movement.Forward.canceled += context => ForwardMovement(context);
        //Right Movement Performed and Cancelled
        inputController.Movement.Right.performed += context => RightMovement(context);
        inputController.Movement.Right.canceled += context => RightMovement(context);
        //Flight performed, no cancel since it go bye bye
        inputController.Movement.Flight.performed += context => AttemptFlight(context);
        //Alitiude performed and cancelled
        inputController.Movement.Altitude.performed += context => AltitudeChange(context);
        inputController.Movement.Altitude.canceled += context => AltitudeChange(context);

        inputController.Constant.Pause.performed += context => ui_Manager.GamePaused();
        #endregion
        ui_Manager.SetCanvas(ui_Manager.startCanvasEnum);
    }

    private void OnDisable()
    {
        if (inputController == null)
            return;
        //Forward Movement Performed and Cancelled
        inputController.Movement.Forward.performed -= context => ForwardMovement(context);
        inputController.Movement.Forward.canceled -= context => ForwardMovement(context);
        //Right Movement Performed and Cancelled
        inputController.Movement.Right.performed -= context => RightMovement(context);
        inputController.Movement.Right.canceled -= context => RightMovement(context);
        //Flight performed, no cancel since it go bye bye
        inputController.Movement.Flight.performed -= context => AttemptFlight(context);
        //Alitiude performed and cancelled
        inputController.Movement.Altitude.performed -= context => AltitudeChange(context);
        inputController.Movement.Altitude.canceled -= context => AltitudeChange(context);
    }

    private void Update()
    {
        Vector3 cameraForwardDirection = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up); //Get's the Camera's forward Vector in the world

        Quaternion rotationToCamera = Quaternion.LookRotation(cameraForwardDirection, Vector3.up); //Turn to Quaternion

        Vector3 directionToMoveTowards = rotationToCamera * movementDirection; //Get the direction we want to move towards in Vector3

        if (movementDirection != Vector3.zero) //Only set's rotation if moving, stops player turning constantly
        {
            playerRotation = Quaternion.LookRotation(directionToMoveTowards, Vector3.up); //Get the rotation the player should meet
        }

        Vector3 finalDirection = new Vector3();

        switch (currentState) //Different finalDirection setups for eithr Ground or Flying.
        {
            case EMovementModes.Ground:

                finalDirection = new Vector3
                (
                    directionToMoveTowards.x * moveSpeedAcceleration,
                    directionToMoveTowards.y,
                    directionToMoveTowards.z * moveSpeedAcceleration
                );
                //Rotate only on Y axis when Ground, stops Diagonal/Upright player rotation
                playerRotation.x = 0;
                playerRotation.z = 0;

                break;
            case EMovementModes.Flying:

                finalDirection = new Vector3
                (
                    directionToMoveTowards.x * moveSpeedAcceleration,
                    directionToMoveTowards.y * altitudeChangeSpeed,
                    directionToMoveTowards.z * moveSpeedAcceleration
                );

                break;

            default:
                break;
        }

        //Player would look diagonal until moving again if this isn't here
        if (movementDirection == Vector3.zero)
        {
            playerRotation.x = 0;
            playerRotation.z = 0;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, rotationSpeed); //Lerp towards camera forward

        transform.position += finalDirection * Time.deltaTime; //Move Player in finalDirection based on deltaTime
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (networkObject == null) //Stops any errors when first instanciating this GameObject
            return;

        if (collision.collider.CompareTag("Ground") && networkObject.IsOwner) //Only attempt to change states if Owner
        { 
            bIsGrounded = true;
            SetState(currentState == EMovementModes.Flying ? EMovementModes.Ground : EMovementModes.Flying);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        bIsGrounded = false;
    }

    /// <summary>
    /// Set's the state to <paramref name="newMode"/> and completes any necessary details based on that
    /// </summary>
    /// <param name="newMode">The mode to switch to</param>
    protected void SetState(EMovementModes newMode)
    {
        if (newMode == currentState)
            return;

        currentState = newMode;

        switch (currentState)
        {
            case EMovementModes.Ground:
                movementDirection.y = 0;
                rb.useGravity = true;
                break;
            case EMovementModes.Flying:
                rb.useGravity = false;
                break;
            default:
                break;
        }
    }

    #region Dynamic Input Events
    /// <summary>
    /// Get's the context and set's the forward vector
    /// </summary>
    /// <param name="context">1 for Forward, 0 for Neutral, -1 for Backwards</param>
    private void ForwardMovement(CallbackContext context)
    {
        movementDirection.z = context.ReadValue<float>();
    }
    /// <summary>
    /// Get's the context and set's the right vector
    /// </summary>
    /// <param name="context">1 for Right, 0 for Neutral, -1 for Left</param>
    private void RightMovement(CallbackContext context)
    {
        movementDirection.x = context.ReadValue<float>();
    }
    /// <summary>
    /// Get's the context and changes the control mode
    /// </summary>
    /// <param name="context">1 for Pressed, 0 for UnPressed</param>
    private void AttemptFlight(CallbackContext context)
    {
        SetState(currentState == EMovementModes.Ground ? EMovementModes.Flying : EMovementModes.Ground);
    }
    /// <summary>
    /// Get's the context and set's the up vector
    /// </summary>
    /// <param name="context">1 for Positive, 0 for Neutral, -1 for Negative</param>
    private void AltitudeChange(CallbackContext context) 
    {
        switch (currentState)
        {
            case EMovementModes.Ground:
                if (bIsGrounded && context.ReadValue<float>() > 0)
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                break;
            case EMovementModes.Flying:
                movementDirection.y = context.ReadValue<float>();
                break;
            default:
                break;
        }
    }
    #endregion
}
