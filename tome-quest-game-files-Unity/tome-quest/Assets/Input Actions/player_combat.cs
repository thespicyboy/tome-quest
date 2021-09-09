// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/player_combat.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_combat : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_combat()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""player_combat"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""73b456cf-bad0-4675-9337-0210ad7b237d"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""ae685cd3-ff1e-4fc2-bfaa-212619ad5dc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""action_perform"",
                    ""type"": ""Value"",
                    ""id"": ""13dbf88b-49c7-40f3-99d8-e5cf7e40c7bb"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8807a94a-3e0a-48db-969d-c8fb0ee85edb"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8fb0626-aa84-4e7b-8805-1402d3c53af2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action_perform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Newaction = m_Player.FindAction("New action", throwIfNotFound: true);
        m_Player_action_perform = m_Player.FindAction("action_perform", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Newaction;
    private readonly InputAction m_Player_action_perform;
    public struct PlayerActions
    {
        private @Player_combat m_Wrapper;
        public PlayerActions(@Player_combat wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Player_Newaction;
        public InputAction @action_perform => m_Wrapper.m_Player_action_perform;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
                @action_perform.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction_perform;
                @action_perform.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction_perform;
                @action_perform.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction_perform;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
                @action_perform.started += instance.OnAction_perform;
                @action_perform.performed += instance.OnAction_perform;
                @action_perform.canceled += instance.OnAction_perform;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnNewaction(InputAction.CallbackContext context);
        void OnAction_perform(InputAction.CallbackContext context);
    }
}
