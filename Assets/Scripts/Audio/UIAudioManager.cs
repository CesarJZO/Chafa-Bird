using Media;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class UIAudioManager : MonoBehaviour
    {
        public static UIAudioManager Instance { get; private set; }

        [SerializeField] private UIAudioMedia media;

        private AudioSource _audioSource;

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySelect()
        {
            _audioSource.PlayOneShot(media.Select);
        }

        public void PlaySubmitAlt()
        {
            _audioSource.PlayOneShot(media.SubmitAlt);
        }

        public void PlayShow()
        {
            _audioSource.PlayOneShot(media.Show);
        }

        public void PlayHide()
        {
            _audioSource.PlayOneShot(media.Hide);
        }
    }
}
