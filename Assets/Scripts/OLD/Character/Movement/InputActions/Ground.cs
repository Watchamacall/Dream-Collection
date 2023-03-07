// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Character/Movement/InputActions/Ground.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Ground : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Ground()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Ground"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""b7133c61-7d66-4a75-af20-1d64d1b9aa18"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""3763c41c-ef28-40fa-8889-6a4b5450c09d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flight"",
                    ""type"": ""Button"",
                    ""id"": ""83114b4e-ba0b-429d-b188-87f3889a2b5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Altitude"",
                    ""type"": ""Button"",
                    ""id"": ""ae41dd27-ee0e-489f-af62-caf6d534e796"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0ac74c2f-1834-447f-bcb7-851725755b28"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d24afc44-d706-437b-9cc4-69ea6f396774"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7d03ca6c-b502-4e85-a7af-18d7b0181fe6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a0169db1-4c51-43df-8393-3d9923f5c409"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c1bf9585-bd42-474c-b243-38ccf9e98cbc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bba43ed2-c445-4fe0-955d-af2da4f97b92"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""UpDown"",
                    ""id"": ""c55b96ec-ab69-4feb-9776-0a3f4d29e2c3"",
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
                    ""id"": ""12309f69-fb7f-454c-a239-3c85f2a6b492"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Altitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0057c450-966f-4679-942e-4aa15f1ca600"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Altitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Altitiude"",
            ""id"": ""37bfba7e-96a8-4c0e-84ac-274cb928af08"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Look"",
            ""id"": ""ca10177b-430a-461e-b3ad-cf84786f04c3"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""75cef788-7256-44ac-a01e-a7d642c8e13f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2faf9fec-4506-4977-847a-b22a64d7d5a0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ConstantControls"",
            ""id"": ""b42b4ab7-341d-4cbe-b7a3-c944906669bf"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""8bff09b4-eda2-4ebf-9848-8ab60a9d5a67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d639b21e-ed3d-402f-8b0f-b04cbf2584fe"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2116d2ec-bf35-4ba5-b94b-856ab08f07f4"",
                    ""path"": ""<Keyboard>/p"",
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
    ""controlSchemes"": []
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Move = m_Move.FindAction("Move", throwIfNotFound: true);
        m_Move_Flight = m_Move.FindAction("Flight", throwIfNotFound: true);
        m_Move_Altitude = m_Move.FindAction("Altitude", throwIfNotFound: true);
        // Altitiude
        m_Altitiude = asset.FindActionMap("Altitiude", throwIfNotFound: true);
        // Look
        m_Look = asset.FindActionMap("Look", throwIfNotFound: true);
        m_Look_Look = m_Look.FindAction("Look", throwIfNotFound: true);
        // ConstantControls
        m_ConstantControls = asset.FindActionMap("ConstantControls", throwIfNotFound: true);
        m_ConstantControls_Pause = m_ConstantControls.FindAction("Pause", throwIfNotFound: true);
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

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Move;
    private readonly InputAction m_Move_Flight;
    private readonly InputAction m_Move_Altitude;
    public struct MoveActions
    {
        private @Ground m_Wrapper;
        public MoveActions(@Ground wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Move_Move;
        public InputAction @Flight => m_Wrapper.m_Move_Flight;
        public InputAction @Altitude => m_Wrapper.m_Move_Altitude;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnMove;
                @Flight.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnFlight;
                @Flight.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnFlight;
                @Flight.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnFlight;
                @Altitude.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnAltitude;
                @Altitude.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnAltitude;
                @Altitude.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnAltitude;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Flight.started += instance.OnFlight;
                @Flight.performed += instance.OnFlight;
                @Flight.canceled += instance.OnFlight;
                @Altitude.started += instance.OnAltitude;
                @Altitude.performed += instance.OnAltitude;
                @Altitude.canceled += instance.OnAltitude;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);

    // Altitiude
    private readonly InputActionMap m_Altitiude;
    private IAltitiudeActions m_AltitiudeActionsCallbackInterface;
    public struct AltitiudeActions
    {
        private @Ground m_Wrapper;
        public AltitiudeActions(@Ground wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Altitiude; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AltitiudeActions set) { return set.Get(); }
        public void SetCallbacks(IAltitiudeActions instance)
        {
            if (m_Wrapper.m_AltitiudeActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_AltitiudeActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public AltitiudeActions @Altitiude => new AltitiudeActions(this);

    // Look
    private readonly InputActionMap m_Look;
    private ILookActions m_LookActionsCallbackInterface;
    private readonly InputAction m_Look_Look;
    public struct LookActions
    {
        private @Ground m_Wrapper;
        public LookActions(@Ground wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Look_Look;
        public InputActionMap Get() { return m_Wrapper.m_Look; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LookActions set) { return set.Get(); }
        public void SetCallbacks(ILookActions instance)
        {
            if (m_Wrapper.m_LookActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_LookActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_LookActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_LookActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_LookActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public LookActions @Look => new LookActions(this);

    // ConstantControls
    private readonly InputActionMap m_ConstantControls;
    private IConstantControlsActions m_ConstantControlsActionsCallbackInterface;
    private readonly InputAction m_ConstantControls_Pause;
    public struct ConstantControlsActions
    {
        private @Ground m_Wrapper;
        public ConstantControlsActions(@Ground wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_ConstantControls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_ConstantControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConstantControlsActions set) { return set.Get(); }
        public void SetCallbacks(IConstantControlsActions instance)
        {
            if (m_Wrapper.m_ConstantControlsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ConstantControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ConstantControlsActions @ConstantControls => new ConstantControlsActions(this);
    public interface IMoveActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFlight(InputAction.CallbackContext context);
        void OnAltitude(InputAction.CallbackContext context);
    }
    public interface IAltitiudeActions
    {
    }
    public interface ILookActions
    {
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IConstantControlsActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
