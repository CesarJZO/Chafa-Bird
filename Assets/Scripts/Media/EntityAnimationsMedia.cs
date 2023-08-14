using UnityEngine;

namespace Media
{
    [CreateAssetMenu(fileName = "Entity Animations Media", menuName = "Media/Animations")]
    public sealed class EntityAnimationsMedia : ScriptableObject
    {
        [SerializeField] private AnimationClip idle;
        public AnimationClip Idle => idle;

        [SerializeField] private AnimationClip jump;
        public AnimationClip Jump => jump;

        [SerializeField] private AnimationClip land;
        public AnimationClip Land => land;

        [SerializeField] private AnimationClip die;
        public AnimationClip Die => die;
    }
}
