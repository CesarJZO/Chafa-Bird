using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class BirdAudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip jumpClip;
        [SerializeField] private AudioClip dieClip;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            Bird.Jumped += OnBirdJumped;
            Bird.Died += OnBirdDied;
        }

        private void OnDestroy()
        {
            Bird.Jumped -= OnBirdJumped;
            Bird.Died -= OnBirdDied;
        }

        private void OnBirdJumped()
        {
            _audioSource.PlayOneShot(jumpClip);
        }

        private void OnBirdDied()
        {
            _audioSource.PlayOneShot(dieClip);
        }
    }
}
