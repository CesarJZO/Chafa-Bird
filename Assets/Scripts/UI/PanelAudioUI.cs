using Media;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class PanelAudioUI : MonoBehaviour
    {
        [SerializeField] private UIAudioMedia audioMedia;
        [SerializeField] private PanelUI panelUI;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            panelUI.OnShow += OnShow;
            panelUI.OnHide += OnHide;
            panelUI.OnButtonClick += OnButtonClick;
        }

        private void OnDestroy()
        {
            panelUI.OnShow -= OnShow;
            panelUI.OnHide -= OnHide;
            panelUI.OnButtonClick -= OnButtonClick;
        }

        private void OnShow()
        {
            _audioSource.PlayOneShot(audioMedia.ShowClip);
        }

        private void OnHide()
        {
            _audioSource.PlayOneShot(audioMedia.HideClip);
        }

        private void OnButtonClick(Button button)
        {
            _audioSource.PlayOneShot(audioMedia.ButtonClickClip);
        }
    }
}
