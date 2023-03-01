using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class ClientController : MonoBehaviour
{
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

    [SerializeField, Tooltip("How fast the player accelerates")]
    protected float moveSpeed = 10.0f;

    [SerializeField, Tooltip("The force the player will jump at")]
    protected float jumpForce = 10.0f;

    [SerializeField, Tooltip("The Vector we wish to move the player in")]
    protected Vector3 movementDirection = Vector3.zero;

    [SerializeField, Tooltip("The speed the player will rotate towards the movement direction"), Range(0,1)]
    protected float rotationSpeed = 0.5f;

    private bool bIsGrounded = true;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        if (inputController == null)
        {
            inputController = new MainPlayerController();
        }

        ui_Manager = GetComponent<UIManager>();

        //Forward Movement Performed and Cancelled
        inputController.Movement.Forward.performed += context => ForwardMovement(context);
        inputController.Movement.Forward.canceled += context => ForwardMovement(context);
        //Right Movement Performed and Cancelled
        inputController.Movement.Right.performed += context => RightMovement(context);
        inputController.Movement.Right.canceled += context => RightMovement(context);
        //Flight performed and cancelled
        inputController.Movement.Flight.performed += context => AttemptFlight(context);
        inputController.Movement.Flight.canceled += context => AttemptFlight(context);
        //Alitiude performed and cancelled
        inputController.Movement.Altitude.performed += context => AltitudeChange(context);
        inputController.Movement.Altitude.canceled += context => AltitudeChange(context);

        //TODO: Make this more generic and able to be used like Blueprints
    }

    private void Update()
    {
        //TODO: Move character in the movementDirection vector

        Vector3 cameraForwardDirection = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up); //Get's the Camera's forward Vector in the world

        Quaternion rotationToCamera = Quaternion.LookRotation(cameraForwardDirection, Vector3.up);
        Debug.Log(rotationToCamera.ToString());
        Vector3 directionToMoveTowards = rotationToCamera * movementDirection;

        Quaternion rotationToMoveDirection = directionToMoveTowards != Vector3.zero ? Quaternion.LookRotation(directionToMoveTowards,Vector3.up) : new Quaternion();

        if (movementDirection != Vector3.zero) //Move the player capsule only when moving
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationToMoveDirection, rotationSpeed);

        Vector3 finalDirection = new Vector3
            (
                directionToMoveTowards.x * moveSpeed, 
                directionToMoveTowards.y * altitudeChangeSpeed, 
                directionToMoveTowards.z * moveSpeed
            );

        transform.position += finalDirection * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Enemy"))
            bIsGrounded = true;
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
        currentState = newMode;

        switch (currentState)
        {
            case EMovementModes.Ground:
                movementDirection.y = 0;
                break;
            case EMovementModes.Flying:

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
        if (currentState == EMovementModes.Flying)
        {
            movementDirection.y = context.ReadValue<float>();
        }
        else if (currentState == EMovementModes.Ground && context.ReadValue<float>() > 0 && !bIsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    #endregion
}
