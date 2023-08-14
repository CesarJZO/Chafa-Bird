using System;
using Core;
using Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Management
{
    public sealed class PauseManager : MonoBehaviour
    {
        public static PauseManager Instance { get; private set; }

        public static event Action Paused;
        public static event Action Resumed;

        [SerializeField] private UnityEvent onPause;
        [SerializeField] private UnityEvent onResume;

        private GameState _previousState;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PauseInput.PausePerformed += OnPausePerformed;
        }

        private void OnDestroy()
        {
            PauseInput.PausePerformed -= OnPausePerformed;
        }

        private void OnPausePerformed(InputAction.CallbackContext context)
        {
            if (GameManager.Instance.CurrentState is GameState.Paused)
                Resume();
            else
                Pause();
        }

        public void Pause()
        {
            _previousState = GameManager.Instance.CurrentState;
            GameManager.Instance.CurrentState = GameState.Paused;

            Time.timeScale = 0f;
            Paused?.Invoke();
            onPause?.Invoke();
        }

        public void Resume()
        {
            GameManager.Instance.CurrentState = _previousState;

            Time.timeScale = 1f;
            Resumed?.Invoke();
            onResume?.Invoke();
        }
    }
}
