using System;
using UnityEngine.InputSystem;

namespace Input
{
    public sealed class PauseInput : GameInput
    {
        public static event Action<InputAction.CallbackContext> PausePerformed;

        private static GameActions _pauseActions;

        protected override void Awake()
        {
            base.Awake();
            _pauseActions = new GameActions();
        }

        private void OnEnable()
        {
            _pauseActions.Pause.Enable();

            _pauseActions.Pause.Pause.performed += PauseAction;
        }

        private void OnDisable()
        {
            _pauseActions.Pause.Disable();

            _pauseActions.Pause.Pause.performed -= PauseAction;
        }

        private static void PauseAction(InputAction.CallbackContext context)
        {
            PausePerformed?.Invoke(context);
            OnAnyInput(context, GameInputAction.Pause);
        }
    }
}
