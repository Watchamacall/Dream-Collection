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

    [SerializeField, Tooltip("How maximum speed the player can reach when moving")]
    protected float maxMoveSpeed = 20.0f;

    [SerializeField, Tooltip("How fast the player accelerates")]
    protected float moveSpeedAcceleration = 10.0f;

    [SerializeField, Tooltip("The Vector we wish to move the player in")]
    protected Vector3 movementDirection = Vector3.zero;

    public Canvas unPausedCanvas;
    public Canvas pausedCanvas;


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
        inputController.Constant.Pause.performed += context => PauseGame();

    }

    private void PauseGame()
    {
        ui_Manager.SetCanvas(pausedCanvas);
    }

    private void Update()
    {
        //TODO: Move character in the movementDirection vector
        Vector3 cameraForwardDirection = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up); //Get's the Camera's forward Vector in the world

        Quaternion rotationToCamera = Quaternion.LookRotation(cameraForwardDirection, Vector3.up);

        Vector3 directionToMoveTowards = rotationToCamera * movementDirection;

        Quaternion rotationToMoveDirection = directionToMoveTowards != Vector3.zero ? Quaternion.LookRotation(directionToMoveTowards,Vector3.up) : new Quaternion();

        Quaternion.RotateTowards(transform.rotation, rotationToCamera, 100.0f);
        
        transform.rotation = rotationToCamera;
        transform.position += (directionToMoveTowards * moveSpeedAcceleration) * Time.deltaTime;
    }

    #region Dynamic Input Events
    private void ForwardMovement(CallbackContext context)
    {
        movementDirection.z = context.ReadValue<float>();
    }
    private void RightMovement(CallbackContext context)
    {
        movementDirection.x = context.ReadValue<float>();
    }

    private void AttemptFlight(CallbackContext context)
    {
        currentState = currentState == EMovementModes.Ground ? EMovementModes.Flying : EMovementModes.Ground;
    }
    private void AltitudeChange(CallbackContext context) 
    {
        if (currentState == EMovementModes.Flying)
        {
            movementDirection.y = context.ReadValue<float>();
        }
    }
    #endregion
}
