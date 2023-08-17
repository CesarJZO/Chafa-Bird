using UnityEngine;

namespace Media
{
    [CreateAssetMenu(fileName = "UIAudioMedia", menuName = "Media/UI", order = 0)]
    public class UIAudioMedia : ScriptableObject
    {
        [SerializeField] private AudioClip showClip;
        [SerializeField] private AudioClip hideClip;
        [SerializeField] private AudioClip buttonClickClip;

        public AudioClip ShowClip => showClip;
        public AudioClip HideClip => hideClip;
        public AudioClip ButtonClickClip => buttonClickClip;
    }
}
