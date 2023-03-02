using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class ClientController : MonoBehaviour
{
    /*
     * Allows for Client Player Movement
     */

    public enum EMovementModes
    {
        Ground = 0,
        Flying = 1,
    }

    private Rigidbody rb;
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

    [SerializeField]
    private bool bIsGrounded = true;

    private Quaternion playerRotation;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        if (inputController == null)
        {
            inputController = new MainPlayerController();
        }

        ui_Manager = GetComponent<UIManager>();

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

    }


    private void Update()
    {
        //TODO: Move character in the movementDirection vector

        Vector3 cameraForwardDirection = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up); //Get's the Camera's forward Vector in the world

        Quaternion rotationToCamera = Quaternion.LookRotation(cameraForwardDirection, Vector3.up); //Turn to Quaternion

        Vector3 directionToMoveTowards = rotationToCamera * movementDirection; //Get the direction we want to move towards

        if (movementDirection != Vector3.zero)
        {
            playerRotation = Quaternion.LookRotation(directionToMoveTowards, Vector3.up); //Get the rotation the player should meet
        }

        Vector3 finalDirection = new Vector3();

        switch (currentState)
        {
            case EMovementModes.Ground:

                finalDirection = new Vector3
                (
                    directionToMoveTowards.x * moveSpeedAcceleration,
                    directionToMoveTowards.y,
                    directionToMoveTowards.z * moveSpeedAcceleration
                );
                //Rotation stays on the y axis to not make it look weird
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

        if (movementDirection == Vector3.zero)
        {
            //The movement would stay at that velocity so reset if movement is zero
            playerRotation.x = 0;
            playerRotation.z = 0;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, rotationSpeed);

        //if (movementDirection != Vector3.zero) //Move the player capsule only when moving
        //    transform.rotation = Quaternion.Lerp(transform.rotation, rotationToMoveDirection, rotationSpeed);

        transform.position += finalDirection * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            bIsGrounded = true;
            if (currentState == EMovementModes.Flying)
            {
                SetState(EMovementModes.Ground);
            }
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
        {
            return;
        }

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
    /// <param name="context"></param>
    private void ForwardMovement(CallbackContext context)
    {
        movementDirection.z = context.ReadValue<float>();
    }
    /// <summary>
    /// Get's the context and set's the right vector
    /// </summary>
    /// <param name="context"></param>
    private void RightMovement(CallbackContext context)
    {
        movementDirection.x = context.ReadValue<float>();
    }
    /// <summary>
    /// Get's the context and changes the control mode
    /// </summary>
    /// <param name="context"></param>
    private void AttemptFlight(CallbackContext context)
    {
        SetState(currentState == EMovementModes.Ground ? EMovementModes.Flying : EMovementModes.Ground);
    }
    /// <summary>
    /// Get's the context and set's the up vector
    /// </summary>
    /// <param name="context"></param>
    private void AltitudeChange(CallbackContext context) 
    {
        switch (currentState)
        {
            case EMovementModes.Ground:
                if (bIsGrounded && context.ReadValue<float>() > 0)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
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
