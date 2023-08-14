using System;
using System.IO;
using Core;
using Management;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public abstract class GameInput : MonoBehaviour
    {
        public static event Action<ControlScheme> ControlSchemeChanged;
        public static event Action<InputAction.CallbackContext, GameInputAction> OnAny;

        private static InputActionAsset _actionsAsset;

        private static ControlScheme _currentControlScheme;

        [SerializeField] protected GameState enabledInStates;

        public static string CurrentDevice { get; private set; }

        public static ControlScheme CurrentControlScheme
        {
            get => _currentControlScheme;
            private set
            {
                if (_currentControlScheme == value) return;
                _currentControlScheme = value;
                ControlSchemeChanged?.Invoke(value);
            }
        }

        public static InputActionAsset ActionsAsset
        {
            get
            {
                if (_actionsAsset) return _actionsAsset;
                _actionsAsset = Resources.Load<InputActionAsset>("Input/GameActions");
                return _actionsAsset;
            }
        }

        protected static void OnAnyInput(InputAction.CallbackContext context, GameInputAction action)
        {
            OnAny?.Invoke(context, action);
        }

        protected virtual void Awake()
        {
            GameManager.StateChanged += OnGameStateChanged;
            InputSystem.onAnyButtonPress.Call(OnAnyButtonPress);
        }

        private void OnDestroy()
        {
            GameManager.StateChanged -= OnGameStateChanged;
        }

        public static string GetBindingForAction(GameInputAction action)
        {
            var index = (int)CurrentControlScheme;
            InputBinding inputBinding = ActionsAsset.FindAction(action.ToString()).bindings[index];
            return inputBinding.ToDisplayString();
        }

        private static void OnAnyButtonPress(InputControl control)
        {
            CurrentDevice = control.device.name;

            CurrentControlScheme = CurrentDevice switch
            {
                "Keyboard" or "Mouse" => ControlScheme.Keyboard,
                "AndroidGamepad" => ControlScheme.AndroidGamepad,
                "PlayStation" => ControlScheme.PLayStation,
                "Switch" => ControlScheme.Switch,
                "WebGLGamepad" => ControlScheme.WebGLGamepad,
                "Xbox" => ControlScheme.Xbox,
                _ => ControlScheme.Gamepad
            };
        }

        private void OnGameStateChanged(GameState state)
        {
            enabled = (enabledInStates & state) == state;
        }
    }
}
