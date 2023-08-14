using System;
using Core;
using Input;
using Management;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Range = Utilities.Range;

namespace Cinematics
{
    public sealed class CutsceneSkipper : MonoBehaviour, IHasProgress
    {
        public event Action<float> ProgressUpdated;

        [SerializeField] private GameState allowInputInState;
        [SerializeField, Min(0f)] private float pressTime;
        [SerializeField] private UnityEvent onProgressCompleted;

        private float _timer;
        private bool _isProgressing;

        public float ProgressNormalized => _timer / pressTime;
        public Range ProgressRange => new(0f, pressTime);

        private void Awake()
        {
            _timer = 0f;
            UIInput.SkipPressed += OnSkipPressed;
            UIInput.SkipReleased += OnSkipReleased;
        }

        private void Update()
        {
            if (!_isProgressing)
                return;

            if (_timer >= pressTime)
            {
                _isProgressing = false;
                _timer = 0f;
                ProgressUpdated?.Invoke(1f);
                onProgressCompleted?.Invoke();
            }
            else
            {
                ProgressUpdated?.Invoke(ProgressNormalized);
            }

            _timer += Time.unscaledDeltaTime;
        }

        private void OnDestroy()
        {
            UIInput.SkipPressed -= OnSkipPressed;
            UIInput.SkipReleased -= OnSkipReleased;
        }

        private void OnSkipPressed(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.CurrentState.HasFlag(allowInputInState))
                return;

            _isProgressing = true;
            _timer = 0f;
            ProgressUpdated?.Invoke(0f);
        }

        private void OnSkipReleased(InputAction.CallbackContext context)
        {
            _isProgressing = false;
            _timer = 0f;
            ProgressUpdated?.Invoke(0f);
        }
    }
}
