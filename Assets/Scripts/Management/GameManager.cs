using System;
using Attributes;
using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Management
{
    public sealed class GameManager : MonoBehaviour
    {
        public static event Action<GameState> StateChanged;

        [Tooltip("The initial state of the game is set to currentState on Start.")]
        [SerializeField] private GameState initialState;
        [SerializeField, ReadOnly] private GameState currentState;

        [SerializeField] private UnityEvent onTutorialState;
        [SerializeField] private UnityEvent onPlayingState;
        [SerializeField] private UnityEvent onPausedState;
        [SerializeField] private UnityEvent onGameOverState;

        public static GameManager Instance { get; private set; }

        public GameState CurrentState
        {
            set
            {
                if (value == currentState) return;
                if (!IsValid(value)) return;
                currentState = value;
                StateChanged?.Invoke(currentState);
            }
            get => currentState;
        }

        private void OnValidate()
        {
            IsValid(initialState);
        }

        private bool IsValid(GameState state)
        {
            // Is valid when state is a power of two. Meaning only one bit is set.
            if ((state & (state - 1)) == 0) return true;

            Debug.LogWarning("Cannot set multiple states at once.", this);
            return false;
        }

        private void Awake()
        {
            Instance = this;
            StateChanged += OnStateChanged;
        }

        private void Start()
        {
            CurrentState = initialState;
        }

        private void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Tutorial: onTutorialState?.Invoke(); break;
                case GameState.Playing: onPlayingState?.Invoke(); break;
                case GameState.Paused: onPausedState?.Invoke(); break;
                case GameState.GameOver: onGameOverState?.Invoke(); break;
            }
        }

        private void OnDestroy()
        {
            StateChanged -= OnStateChanged;
        }
    }
}
