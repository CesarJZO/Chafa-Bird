using Core;
using Input;
using Management;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public sealed class TogglePanelUI : MonoBehaviour
    {
        [SerializeField] private bool startHidden;
        [SerializeField] private GameState allowedStates;
        [SerializeField] private GameInputAction showOnInput;
        [SerializeField]
        [Min(0f)]
        private float showForSeconds;

        private bool _holdingInput;
        private float _timer;

        private void Start()
        {
            if (startHidden)
                Hide();
        }

        private void Awake()
        {
            GameInput.OnAny += OnAnyInput;
        }

        private void OnDestroy()
        {
            GameInput.OnAny -= OnAnyInput;
        }

        private void OnAnyInput(InputAction.CallbackContext context, GameInputAction action)
        {
            if (allowedStates != 0 && !GameManager.Instance.CurrentState.HasFlag(allowedStates))
                return;

            if (action != showOnInput) return;

            _holdingInput = context.performed;

            if (!context.performed) return;

            _timer = 0f;
            Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (showForSeconds <= 0f)
                return;

            if (_holdingInput)
                _timer = 0f;

            if (!gameObject.activeSelf) return;

            if (_timer >= showForSeconds)
            {
                _timer = 0f;
                Hide();
            }

            _timer += Time.unscaledDeltaTime;
        }
    }
}
