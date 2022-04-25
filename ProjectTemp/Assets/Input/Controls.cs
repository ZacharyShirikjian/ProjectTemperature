// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b11b8da0-38ff-47be-8e76-879341dca457"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""21ff37a6-71f8-414a-8233-82d3d4b9579b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""28df1a49-05a5-4742-abbe-fe90fb00926c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""a28abb53-e2c1-495f-ae5e-71f8401e00f3"",
            ""actions"": [
                {
                    ""name"": ""CloseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""2c2ef36a-c6a3-4423-b3ee-558df3804bc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98acbf68-0030-438d-b31d-2e6ac60f3c05"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""CloseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""bindingGroup"": ""Keyboard/Mouse"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_CloseMenu = m_Menus.FindAction("CloseMenu", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Shoot;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private IMenusActions m_MenusActionsCallbackInterface;
    private readonly InputAction m_Menus_CloseMenu;
    public struct MenusActions
    {
        private @Controls m_Wrapper;
        public MenusActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseMenu => m_Wrapper.m_Menus_CloseMenu;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void SetCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterface != null)
            {
                @CloseMenu.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnCloseMenu;
                @CloseMenu.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnCloseMenu;
                @CloseMenu.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnCloseMenu;
            }
            m_Wrapper.m_MenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CloseMenu.started += instance.OnCloseMenu;
                @CloseMenu.performed += instance.OnCloseMenu;
                @CloseMenu.canceled += instance.OnCloseMenu;
            }
        }
    }
    public MenusActions @Menus => new MenusActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard/Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnCloseMenu(InputAction.CallbackContext context);
    }
}
