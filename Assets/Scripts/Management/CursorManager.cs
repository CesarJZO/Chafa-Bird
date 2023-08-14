using Attributes;
using Core;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Management
{
    public sealed class CursorManager : MonoBehaviour
    {
        [SerializeField] private GameState mouseVisibleOnStates;
        [SerializeField] private bool allowVisibleOnClick;
        [SerializeField]
        [ShowIfBool(nameof(allowVisibleOnClick))]
        [Min(0f)]
        private float timeVisible;
        [SerializeField] private bool visibleOnControllerScheme;

        private void Awake()
        {
            GameManager.StateChanged += OnGameStateChanged;
            GameInput.ControlSchemeChanged += OnControlSchemeChanged;
            UIInput.LeftClickPerformed += OnClickPerformed;
            UIInput.RightClickPerformed += OnClickPerformed;
            UIInput.MiddleClickPerformed += OnClickPerformed;
        }

        private void OnDestroy()
        {
            GameManager.StateChanged -= OnGameStateChanged;
            GameInput.ControlSchemeChanged -= OnControlSchemeChanged;
            UIInput.LeftClickPerformed -= OnClickPerformed;
            UIInput.RightClickPerformed -= OnClickPerformed;
            UIInput.MiddleClickPerformed -= OnClickPerformed;
        }

        private void OnGameStateChanged(GameState state)
        {
            Cursor.visible = (state & mouseVisibleOnStates) is not 0
                             && (visibleOnControllerScheme
                             || GameInput.CurrentControlScheme is ControlScheme.Keyboard);
        }

        private void OnControlSchemeChanged(ControlScheme scheme)
        {
            Cursor.visible = visibleOnControllerScheme || scheme is ControlScheme.Keyboard;
        }

        private void OnClickPerformed(InputAction.CallbackContext context)
        {
            if (!allowVisibleOnClick) return;
            Cursor.visible = true;
            if (timeVisible <= 0) return;
            Invoke(nameof(ResetVisible), timeVisible);
        }

        private void ResetVisible()
        {
            Cursor.visible = false;
        }
    }
}
