using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Cinematics
{
    public sealed class EntityCutsceneController : Cutscene
    {
        [SerializeField] private GameObject animableEntity;
        [Tooltip("The position where the entity is expected to be at the end of the animation. Useful in case the animation is skipped.")]
        [SerializeField] private Transform endPosition;
        [SerializeField] private UnityEvent onStartAnimating;
        [SerializeField] private UnityEvent onStopAnimating;

        private IAnimable _animableComponent;

        private void Awake()
        {
            ValidateEntity();
        }

        private void ValidateEntity()
        {
            if (!animableEntity) return;

            if (!animableEntity.TryGetComponent(out _animableComponent))
                Debug.Log($"{animableEntity.name} does not have an <b>IAnimable</b> component", this);
        }

        public void ChangeState(string state)
        {
            if (!Application.isPlaying) return;

            _animableComponent?.ChangeState(state);
        }

        public void FaceDirection(float direction)
        {
            if (!Application.isPlaying) return;

            _animableComponent?.FaceDirection(direction);
        }

        public override void Play()
        {
            if (!Application.isPlaying) return;

            if (_animableComponent is not null)
                _animableComponent.Animating = true;

            onStartAnimating?.Invoke();
        }

        public override void Stop()
        {
            if (!Application.isPlaying) return;

            if (_animableComponent is not null)
            {
                _animableComponent.Animating = false;
                _animableComponent.Idle(endPosition.localScale.x.Sign());
            }

            onStopAnimating?.Invoke();
        }

        public override void Skip()
        {
            _animableComponent?.MoveTo(endPosition);
            Stop();
        }
    }
}
