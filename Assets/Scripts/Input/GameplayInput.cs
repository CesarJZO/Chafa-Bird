using System;
using UnityEngine.InputSystem;

namespace Input
{
    public sealed class GameplayInput : GameInput
    {
        #region Events

        public static event Action<InputAction.CallbackContext> OnJump;

        #endregion

        private static GameActions _gameplayActions;

        protected override void Awake()
        {
            base.Awake();
            _gameplayActions = new GameActions();
        }

        private void OnEnable()
        {
            _gameplayActions.Bird.Enable();

            _gameplayActions.Bird.Jump.performed += JumpAction;
            _gameplayActions.Bird.Jump.canceled += JumpAction;
        }

        private void OnDisable()
        {
            _gameplayActions.Bird.Disable();

            _gameplayActions.Bird.Jump.performed -= JumpAction;
            _gameplayActions.Bird.Jump.canceled -= JumpAction;
        }

        private static void JumpAction(InputAction.CallbackContext context)
        {
            OnJump?.Invoke(context);
            OnAnyInput(context, GameInputAction.Jump);
        }
    }
}
