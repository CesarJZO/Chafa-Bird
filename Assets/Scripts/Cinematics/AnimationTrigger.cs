using System;
using UnityEngine;
using UnityEngine.Events;

namespace Cinematics
{
    public sealed class AnimationTrigger : MonoBehaviour
    {
        [SerializeField] private string startTrigger;
        [SerializeField] private UnityEvent onStart;

        [SerializeField] private string endTrigger;
        [SerializeField] private UnityEvent onEnd;

        private void Awake()
        {
            AnimationEvent.Started += OnStarted;
            AnimationEvent.Ended += OnEnded;
        }

        private void OnDestroy()
        {
            AnimationEvent.Started -= OnStarted;
            AnimationEvent.Ended -= OnEnded;
        }

        private void OnStarted(string trigger)
        {
            ReadOnlySpan<char> triggerSpan = trigger.AsSpan().Trim();
            ReadOnlySpan<char> startTriggerSpan = startTrigger.AsSpan().Trim();

            if (triggerSpan.IsEmpty || startTriggerSpan.IsEmpty)
                return;

            if (triggerSpan.SequenceEqual(startTriggerSpan))
                onStart?.Invoke();
        }

        private void OnEnded(string trigger)
        {
            ReadOnlySpan<char> triggerSpan = trigger.AsSpan().Trim();
            ReadOnlySpan<char> endTriggerSpan = endTrigger.AsSpan().Trim();

            if (triggerSpan.IsEmpty || endTriggerSpan.IsEmpty)
                return;

            if (triggerSpan.SequenceEqual(endTriggerSpan))
                onEnd?.Invoke();
        }
    }
}
