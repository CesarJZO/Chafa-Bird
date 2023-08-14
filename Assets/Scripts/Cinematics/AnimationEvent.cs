using System;
using UnityEngine;

namespace Cinematics
{
    public sealed class AnimationEvent : StateMachineBehaviour
    {
        [SerializeField] private string startTrigger;
        [SerializeField] private string endTrigger;

        public static event Action<string> Started;
        public static event Action<string> Ended;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Started?.Invoke(startTrigger);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Ended?.Invoke(endTrigger);
        }
    }
}
