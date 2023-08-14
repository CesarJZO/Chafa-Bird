using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public sealed class GameplayInput : GameInput
    {
        #region Events

        public static event Action<InputAction.CallbackContext> OnJump;
        public static event Action<InputAction.CallbackContext> OnMove;
        public static event Action<InputAction.CallbackContext> OnShoot;

        #endregion

        public static Vector2 MoveDirection => _gameplayActions.Ground.Move.ReadValue<Vector2>();

        private static GameActions _gameplayActions;

        protected override void Awake()
        {
            base.Awake();
            _gameplayActions = new GameActions();
        }

        private void OnEnable()
        {
            _gameplayActions.Ground.Enable();

            _gameplayActions.Ground.Jump.performed += JumpAction;
            _gameplayActions.Ground.Jump.canceled += JumpAction;

            _gameplayActions.Ground.Move.performed += MoveAction;
            _gameplayActions.Ground.Move.canceled += MoveAction;

            _gameplayActions.Ground.Shoot.performed += ShootAction;
            _gameplayActions.Ground.Shoot.canceled += ShootAction;
        }

        private void OnDisable()
        {
            _gameplayActions.Ground.Disable();

            _gameplayActions.Ground.Jump.performed -= JumpAction;
            _gameplayActions.Ground.Jump.canceled -= JumpAction;

            _gameplayActions.Ground.Move.performed -= MoveAction;
            _gameplayActions.Ground.Move.canceled -= MoveAction;

            _gameplayActions.Ground.Shoot.performed -= ShootAction;
            _gameplayActions.Ground.Shoot.canceled -= ShootAction;
        }

        private static void JumpAction(InputAction.CallbackContext context)
        {
            OnJump?.Invoke(context);
            OnAnyInput(context, GameInputAction.Jump);
        }

        private static void MoveAction(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context);
            OnAnyInput(context, GameInputAction.Move);
        }

        private static void ShootAction(InputAction.CallbackContext context)
        {
            OnShoot?.Invoke(context);
            OnAnyInput(context, GameInputAction.Shoot);
        }
    }
}
