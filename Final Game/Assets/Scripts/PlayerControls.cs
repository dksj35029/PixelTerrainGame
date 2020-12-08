// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Camp"",
            ""id"": ""0cefbd56-e6e6-4d98-a790-a730ca81c0f0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c5fe3bd5-2b1e-4656-8169-ebadc4b01699"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""282138b9-4e09-4500-8f11-11c73f83f906"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4a013cb2-3b07-4254-84e5-9daa49cdb467"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inspect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d02eee4c-4988-4a48-b307-cebaa8b85d32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Number1"",
                    ""type"": ""Button"",
                    ""id"": ""5253a2a9-e9fa-4671-a61a-d65c8d3dd011"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Number2"",
                    ""type"": ""Button"",
                    ""id"": ""85d61da6-fd83-437d-bf16-b5d403ca1010"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""8c8184ce-523b-4d67-a5d6-3823ac7c7947"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6543417a-1033-476c-8dc1-99cb6e06c610"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""34a5b857-8510-4926-af76-4a9f7eb1c923"",
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
                    ""id"": ""52bd0534-67a3-4543-ac3b-29a13258a5a3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab7bbd59-da82-4945-b2db-b8bca8f3f2a4"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b78d655-c795-42e4-b21d-1831b4aec33d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cde8a630-9f2b-4085-a955-dacd0ea9b26d"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d5658a2-9f9b-4a16-8947-77f1fa7873cd"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camp
        m_Camp = asset.FindActionMap("Camp", throwIfNotFound: true);
        m_Camp_Move = m_Camp.FindAction("Move", throwIfNotFound: true);
        m_Camp_Jump = m_Camp.FindAction("Jump", throwIfNotFound: true);
        m_Camp_Attack = m_Camp.FindAction("Attack", throwIfNotFound: true);
        m_Camp_Inspect = m_Camp.FindAction("Inspect", throwIfNotFound: true);
        m_Camp_Number1 = m_Camp.FindAction("Number1", throwIfNotFound: true);
        m_Camp_Number2 = m_Camp.FindAction("Number2", throwIfNotFound: true);
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

    // Camp
    private readonly InputActionMap m_Camp;
    private ICampActions m_CampActionsCallbackInterface;
    private readonly InputAction m_Camp_Move;
    private readonly InputAction m_Camp_Jump;
    private readonly InputAction m_Camp_Attack;
    private readonly InputAction m_Camp_Inspect;
    private readonly InputAction m_Camp_Number1;
    private readonly InputAction m_Camp_Number2;
    public struct CampActions
    {
        private @PlayerControls m_Wrapper;
        public CampActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Camp_Move;
        public InputAction @Jump => m_Wrapper.m_Camp_Jump;
        public InputAction @Attack => m_Wrapper.m_Camp_Attack;
        public InputAction @Inspect => m_Wrapper.m_Camp_Inspect;
        public InputAction @Number1 => m_Wrapper.m_Camp_Number1;
        public InputAction @Number2 => m_Wrapper.m_Camp_Number2;
        public InputActionMap Get() { return m_Wrapper.m_Camp; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CampActions set) { return set.Get(); }
        public void SetCallbacks(ICampActions instance)
        {
            if (m_Wrapper.m_CampActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CampActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CampActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CampActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_CampActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CampActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CampActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_CampActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CampActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CampActionsCallbackInterface.OnAttack;
                @Inspect.started -= m_Wrapper.m_CampActionsCallbackInterface.OnInspect;
                @Inspect.performed -= m_Wrapper.m_CampActionsCallbackInterface.OnInspect;
                @Inspect.canceled -= m_Wrapper.m_CampActionsCallbackInterface.OnInspect;
                @Number1.started -= m_Wrapper.m_CampActionsCallbackInterface.OnNumber1;
                @Number1.performed -= m_Wrapper.m_CampActionsCallbackInterface.OnNumber1;
                @Number1.canceled -= m_Wrapper.m_CampActionsCallbackInterface.OnNumber1;
                @Number2.started -= m_Wrapper.m_CampActionsCallbackInterface.OnNumber2;
                @Number2.performed -= m_Wrapper.m_CampActionsCallbackInterface.OnNumber2;
                @Number2.canceled -= m_Wrapper.m_CampActionsCallbackInterface.OnNumber2;
            }
            m_Wrapper.m_CampActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Inspect.started += instance.OnInspect;
                @Inspect.performed += instance.OnInspect;
                @Inspect.canceled += instance.OnInspect;
                @Number1.started += instance.OnNumber1;
                @Number1.performed += instance.OnNumber1;
                @Number1.canceled += instance.OnNumber1;
                @Number2.started += instance.OnNumber2;
                @Number2.performed += instance.OnNumber2;
                @Number2.canceled += instance.OnNumber2;
            }
        }
    }
    public CampActions @Camp => new CampActions(this);
    public interface ICampActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnInspect(InputAction.CallbackContext context);
        void OnNumber1(InputAction.CallbackContext context);
        void OnNumber2(InputAction.CallbackContext context);
    }
}
