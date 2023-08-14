using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public sealed class UIInput : GameInput
    {
        public static event Action<InputAction.CallbackContext> SkipPressed;
        public static event Action<InputAction.CallbackContext> SkipReleased;
        public static event Action<InputAction.CallbackContext> NavigatePerformed;
        public static event Action<InputAction.CallbackContext> SubmitPerformed;
        public static event Action<InputAction.CallbackContext> CancelPerformed;
        public static event Action<InputAction.CallbackContext> LeftClickPerformed;
        public static event Action<InputAction.CallbackContext> RightClickPerformed;
        public static event Action<InputAction.CallbackContext> MiddleClickPerformed;

        public static Vector2 Direction => _uiActions.UI.Navigate.ReadValue<Vector2>();
        public static bool SkipIsPressed { get; private set; }

        private static GameActions _uiActions;

        protected override void Awake()
        {
            base.Awake();
            _uiActions = new GameActions();
        }

        private void OnEnable()
        {
            _uiActions.UI.Enable();

            _uiActions.UI.Navigate.performed += NavigateAction;
            _uiActions.UI.Submit.performed += SubmitAction;
            _uiActions.UI.Cancel.performed += CancelAction;
            _uiActions.UI.Skip.performed += SkipAction;
            _uiActions.UI.Skip.canceled += SkipAction;
            _uiActions.UI.Click.performed += ClickAction;
            _uiActions.UI.RightClick.performed += RightClickAction;
            _uiActions.UI.MiddleClick.performed += MiddleClickAction;
        }

        private void OnDisable()
        {
            _uiActions.UI.Disable();

            _uiActions.UI.Navigate.performed -= NavigateAction;
            _uiActions.UI.Submit.performed -= SubmitAction;
            _uiActions.UI.Cancel.performed -= CancelAction;
            _uiActions.UI.Skip.performed -= SkipAction;
            _uiActions.UI.Skip.canceled -= SkipAction;
            _uiActions.UI.Click.performed -= ClickAction;
            _uiActions.UI.RightClick.performed -= RightClickAction;
            _uiActions.UI.MiddleClick.performed -= MiddleClickAction;
        }

        private static void NavigateAction(InputAction.CallbackContext context)
        {
            NavigatePerformed?.Invoke(context);
            OnAnyInput(context, GameInputAction.Navigate);
        }

        private static void SubmitAction(InputAction.CallbackContext context)
        {
            SubmitPerformed?.Invoke(context);
            OnAnyInput(context, GameInputAction.Submit);
        }

        private static void CancelAction(InputAction.CallbackContext context)
        {
            CancelPerformed?.Invoke(context);
            OnAnyInput(context, GameInputAction.Cancel);
        }

        private static void SkipAction(InputAction.CallbackContext context)
        {
            SkipIsPressed = context.performed;
            if (context.performed)
                SkipPressed?.Invoke(context);
            else if (context.canceled)
                SkipReleased?.Invoke(context);
            OnAnyInput(context, GameInputAction.Skip);
        }

        private static void ClickAction(InputAction.CallbackContext context)
        {
            LeftClickPerformed?.Invoke(context);
            OnAnyInput(context, GameInputAction.Click);
        }

        private static void RightClickAction(InputAction.CallbackContext context)
        {
            RightClickPerformed?.Invoke(context);
            OnAnyInput(context, GameInputAction.RightClick);
        }

        private static void MiddleClickAction(InputAction.CallbackContext context)
        {
            MiddleClickPerformed?.Invoke(context);
            OnAnyInput(context, GameInputAction.MiddleClick);
        }
    }
}
