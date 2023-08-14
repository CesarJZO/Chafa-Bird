using System;
using UnityEngine;

namespace Core
{
    public sealed class StateMachine<T> where T : MonoBehaviour
    {
        public event Action<State<T>> StateChanged;

        public State<T> CurrentState { get; private set; }

        public void Initialize(State<T> startingState)
        {
            CurrentState = startingState;
            CurrentState.OnStart();
            StateChanged?.Invoke(CurrentState);
        }

        public void ChangeState(State<T> state)
        {
            CurrentState.OnEnd();
            CurrentState = state;
            CurrentState.OnStart();
            StateChanged?.Invoke(CurrentState);
        }

        public void Kill()
        {
            CurrentState?.OnEnd();
            CurrentState = new NullState();
        }

        private class NullState : State<T>
        {
            public NullState() : base(null, null) { }

            public override string ToString() => nameof(NullState);
        }
    }
}
