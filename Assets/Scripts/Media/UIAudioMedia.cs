using UnityEngine;

namespace Media
{
    [CreateAssetMenu(fileName = "UIAudioMedia", menuName = "Media/UI Audio")]
    public sealed class UIAudioMedia : ScriptableObject
    {
        [SerializeField] private AudioClip select;
        public AudioClip Select => select;

        [SerializeField] private AudioClip submitAlt;
        public AudioClip SubmitAlt => submitAlt;

        [SerializeField] private AudioClip show;
        public AudioClip Show => show;

        [SerializeField] private AudioClip hide;
        public AudioClip Hide => hide;
    }
}
