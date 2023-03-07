using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;
using TMPro;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public enum MovementState
{
    Ground,
    Flying,
}

[RequireComponent(typeof(Rigidbody))]
public class Move : PlayerBehavior
{

    private Rigidbody rb;
    [SerializeField] private Vector3 movDir = Vector3.zero;
    private MovementState state = MovementState.Ground;

    private bool isGrounded = true;

    [Tooltip("How fast the altitude changes when in flight mode")]
    public float altitudeChange = 1;

    [Tooltip("The movementSpeed for the player")]
    public float movSpeed;

    [Tooltip("How fast the player can actually go")]
    public float maxMovSpeed;

    [Tooltip("How fast the player rotates towards the cam direction")]
    public float rotSpeed = 360.0f;

    [Tooltip("Tick this for constant rotation of the player")]
    public bool constRot = false;

    [Tooltip("Tick this for transform movement")]
    public bool transformMov = false;

    public Slider slider;
    public float maxHealth;
    [SerializeField]private float health;
    ControlsManager manager;

    public float Health
    {
        get { return health; }
        set { health = Mathf.Clamp(value, 0, maxHealth); }
    }

    private void OnEnable()
    {
        //Setting all the bindings 
        manager = GameObject.Find("GameLogic").GetComponent<ControlsManager>();
        manager.controls.Move.Move.performed += context => OnMove(context);
        manager.controls.Move.Move.canceled += context => OnMove(context);
        manager.controls.Move.Flight.performed += context => Fly(context);
        manager.controls.Move.Altitude.performed += context => OnAltitudeChange(context);
        manager.controls.Move.Altitude.canceled += context => OnAltitudeChange(context);
    }
    private void OnDisable()
    {
        //Removing all bindings
        manager.controls.Move.Move.performed -= context => OnMove(context);
        manager.controls.Move.Move.canceled -= context => OnMove(context);
        manager.controls.Move.Flight.performed -= context => Fly(context);
        manager.controls.Move.Flight.canceled -= context => Fly(context);
        manager.controls.Move.Altitude.performed -= context => OnAltitudeChange(context);
        manager.controls.Move.Altitude.canceled -= context => OnAltitudeChange(context);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        health = maxHealth;

        //Locks the mouse and turns it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        slider.value = health;

        Vector3 projectCamForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up); //Gain the main Cam x+ axis

        Quaternion rotToCam = Quaternion.LookRotation(projectCamForward, Vector3.up); //Get rotation of the main Cam

        Vector3 camMov = rotToCam * movDir; //Sets the direction to move towards the Cam x+

        Quaternion rotToMovDir = new Quaternion();

        if (camMov != Vector3.zero)
        {
            rotToMovDir = Quaternion.LookRotation(camMov, Vector3.up); //Gets direction of the player
        }

        if (constRot)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotToCam, rotSpeed * Time.deltaTime); //Constantly moves the player in the direction of the camera
        }
        else //Adventure Mode Rotation
        {
            if (movDir.magnitude > 0) //If the player starts moving
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotToMovDir, rotSpeed * Time.deltaTime); //Rotates the player towards the Cam's forward direction
            }
        }

        if (transformMov)
        {
            transform.position += camMov * movSpeed * Time.deltaTime; //Moves the player over transform
        }
        else
        {
            if (rb.velocity.magnitude < maxMovSpeed) //If the player hasn't hit the maxMovSpeed cap
            {
                //rb.AddForce(camMov * movSpeed); //Add Force to the player 
                rb.position += (camMov * movSpeed * Time.deltaTime); //Position changing of the Rigidbody
            }
        }
    }

    #region Dynamic Input Events
    public void OnMove(CallbackContext context)
    {
        Vector2 movDirection = context.ReadValue<Vector2>();
        movDir.z = Vector3.forward.z * context.ReadValue<Vector2>().y; //Setting left/right
        movDir.x = Vector3.right.x * context.ReadValue<Vector2>().x; //Setting forward/backward
    }

    public void Fly(CallbackContext context)
    {
        if (state == MovementState.Flying)
        {
            rb.useGravity = true;
            state = MovementState.Ground;

        }
        else if (state == MovementState.Ground && isGrounded)
        {
            rb.useGravity = false;
            state = MovementState.Flying;
        }
    }

    public void OnAltitudeChange(CallbackContext context)
    {
        if (rb.useGravity && isGrounded || !rb.useGravity)
        {
            movDir.y = context.ReadValue<float>() * altitudeChange;
        }
        else if (rb.useGravity && !isGrounded)
        {
            movDir.y = 0;
        }
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public override void SendPlayerInformation(RpcArgs args)
    {
        throw new System.NotImplementedException();
    }

    public override void DestroyPlayer(RpcArgs args)
    {
        throw new System.NotImplementedException();
    }
}
