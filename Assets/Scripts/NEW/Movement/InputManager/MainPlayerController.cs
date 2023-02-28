// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/NEW/Movement/InputManager/MainPlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainPlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainPlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainPlayerController"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""7100fb36-8275-4158-8272-6e23b216c110"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""94a5be5f-f20c-45e1-9b76-1a3d2e1edfba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""20b4eac1-d847-40fc-bcff-26660a182981"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flight"",
                    ""type"": ""Button"",
                    ""id"": ""5b3b769e-4f38-4079-88e0-def9f15e4d5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Altitude"",
                    ""type"": ""Button"",
                    ""id"": ""548a19bc-6cda-45b4-9132-7de4913c6f28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0568912-1ac5-464b-8674-1d3427820ba6"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2e63f4ae-392a-4aa5-8c4e-29501fb37d28"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Altitude"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d66f86cc-bc94-47bb-ad2a-48efae98b55f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Altitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1fee4bfb-0ad8-4188-8f66-e199978026bb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Altitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Forward"",
                    ""id"": ""168513ea-ae19-4bef-889c-c134f1dbfd71"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""13792610-b780-4728-96f2-faee12e22186"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""1527393c-bb4c-487b-a097-7c6f312afac0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""04d5c281-2ce2-455a-8bb5-d6c67071fda2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""61ff8b1c-ee06-45ee-b0eb-6d46cc1d5c90"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f367a769-27c0-45f7-b685-ce53d1dcd25a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Look"",
            ""id"": ""cb4a4f5a-684d-44ff-9b97-527b899255a0"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""cdf423d0-9545-45fb-a821-f81c8cf1d845"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92114451-9fdf-4ce9-8b8b-5390bb963a5f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Constant"",
            ""id"": ""b7b47939-9e78-4554-b051-8f173391d69f"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""33e703c1-f805-47a3-a98f-c2995452d5a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e9d893ed-a698-472e-9af3-1183604ea605"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f94feaa-2150-49be-902e-deace82c407a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Forward = m_Movement.FindAction("Forward", throwIfNotFound: true);
        m_Movement_Right = m_Movement.FindAction("Right", throwIfNotFound: true);
        m_Movement_Flight = m_Movement.FindAction("Flight", throwIfNotFound: true);
        m_Movement_Altitude = m_Movement.FindAction("Altitude", throwIfNotFound: true);
        // Look
        m_Look = asset.FindActionMap("Look", throwIfNotFound: true);
        m_Look_Mouse = m_Look.FindAction("Mouse", throwIfNotFound: true);
        // Constant
        m_Constant = asset.FindActionMap("Constant", throwIfNotFound: true);
        m_Constant_Pause = m_Constant.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Forward;
    private readonly InputAction m_Movement_Right;
    private readonly InputAction m_Movement_Flight;
    private readonly InputAction m_Movement_Altitude;
    public struct MovementActions
    {
        private @MainPlayerController m_Wrapper;
        public MovementActions(@MainPlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Movement_Forward;
        public InputAction @Right => m_Wrapper.m_Movement_Right;
        public InputAction @Flight => m_Wrapper.m_Movement_Flight;
        public InputAction @Altitude => m_Wrapper.m_Movement_Altitude;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                @Right.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                @Flight.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnFlight;
                @Flight.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnFlight;
                @Flight.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnFlight;
                @Altitude.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAltitude;
                @Altitude.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAltitude;
                @Altitude.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAltitude;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Flight.started += instance.OnFlight;
                @Flight.performed += instance.OnFlight;
                @Flight.canceled += instance.OnFlight;
                @Altitude.started += instance.OnAltitude;
                @Altitude.performed += instance.OnAltitude;
                @Altitude.canceled += instance.OnAltitude;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Look
    private readonly InputActionMap m_Look;
    private ILookActions m_LookActionsCallbackInterface;
    private readonly InputAction m_Look_Mouse;
    public struct LookActions
    {
        private @MainPlayerController m_Wrapper;
        public LookActions(@MainPlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_Look_Mouse;
        public InputActionMap Get() { return m_Wrapper.m_Look; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LookActions set) { return set.Get(); }
        public void SetCallbacks(ILookActions instance)
        {
            if (m_Wrapper.m_LookActionsCallbackInterface != null)
            {
                @Mouse.started -= m_Wrapper.m_LookActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_LookActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_LookActionsCallbackInterface.OnMouse;
            }
            m_Wrapper.m_LookActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
            }
        }
    }
    public LookActions @Look => new LookActions(this);

    // Constant
    private readonly InputActionMap m_Constant;
    private IConstantActions m_ConstantActionsCallbackInterface;
    private readonly InputAction m_Constant_Pause;
    public struct ConstantActions
    {
        private @MainPlayerController m_Wrapper;
        public ConstantActions(@MainPlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Constant_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Constant; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConstantActions set) { return set.Get(); }
        public void SetCallbacks(IConstantActions instance)
        {
            if (m_Wrapper.m_ConstantActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_ConstantActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ConstantActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ConstantActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ConstantActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ConstantActions @Constant => new ConstantActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnFlight(InputAction.CallbackContext context);
        void OnAltitude(InputAction.CallbackContext context);
    }
    public interface ILookActions
    {
        void OnMouse(InputAction.CallbackContext context);
    }
    public interface IConstantActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
