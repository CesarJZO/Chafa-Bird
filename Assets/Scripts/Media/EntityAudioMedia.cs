using UnityEngine;

namespace Media
{
    [CreateAssetMenu(fileName = "Entity Audio Media", menuName = "Media/Audio")]
    public sealed class EntityAudioMedia : ScriptableObject
    {
        [SerializeField] private AudioClip jump;
        public AudioClip Jump => jump;

        [SerializeField] private AudioClip death;
        public AudioClip Death => death;

        [SerializeField] private AudioClip shoot;
        public AudioClip Shoot => shoot;

        [SerializeField] private AudioClip land;
        public AudioClip Land => land;

        [SerializeField] private AudioClip hit;
        public AudioClip Hit => hit;

        [SerializeField] private AudioClip collect;
        public AudioClip Collect => collect;
    }
}
