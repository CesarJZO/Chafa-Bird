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

        [SerializeField] private UnityEvent onSceneIntroState;
        [SerializeField] private UnityEvent onPlayingState;
        [SerializeField] private UnityEvent onPausedState;
        [SerializeField] private UnityEvent onSceneOutroState;
        [SerializeField] private UnityEvent onCutsceneState;

        public static GameManager Instance { get; private set; }

        public GameState CurrentState
        {
            set
            {
                if (value == currentState) return;
                // If value has multiple flags, return
                if (value != 0 && (value & (value - 1)) != 0)
                {
                    Debug.LogWarning("Cannot set multiple states at once.", this);
                    return;
                }
                currentState = value;
                StateChanged?.Invoke(currentState);
            }
            get => currentState;
        }

        private void OnValidate()
        {
            if ((initialState & (initialState - 1)) != 0)
                Debug.LogWarning("Cannot set multiple states at once.", this);
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
                case GameState.SceneIntro: onSceneIntroState?.Invoke(); break;
                case GameState.Playing: onPlayingState?.Invoke(); break;
                case GameState.Paused: onPausedState?.Invoke(); break;
                case GameState.SceneOutro: onSceneOutroState?.Invoke(); break;
                case GameState.Cutscene: onCutsceneState?.Invoke(); break;
            }
        }

        private void OnDestroy()
        {
            StateChanged -= OnStateChanged;
        }
    }
}
