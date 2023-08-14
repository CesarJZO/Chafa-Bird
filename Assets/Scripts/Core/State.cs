using UnityEngine;

namespace Core
{
    public abstract class State<T> where T : MonoBehaviour
    {
        protected readonly T Owner;
        protected readonly StateMachine<T> StateMachine;

        protected State(T owner, StateMachine<T> stateMachine)
        {
            Owner = owner;
            StateMachine = stateMachine;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public virtual void OnStart() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        // ReSharper disable Unity.PerformanceAnalysis
        public virtual void OnEnd() { }
    }
}
