using Audio;
using Core;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class PauseUI : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button exitToTitleButton;

        private UIAudioManager _audioManager;

        private void Start()
        {
            OnResume();

            _audioManager = UIAudioManager.Instance;

            if (resumeButton)
            {
                resumeButton.onClick.AddListener(PauseManager.Instance.Resume);
                UIManager.CurrentSelectedObject = resumeButton.gameObject;
            }

            if (exitToTitleButton)
            {
                exitToTitleButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(GameScene.MainMenu);
                    if (_audioManager) _audioManager.PlaySelect();
                });
            }

            PauseManager.Paused += OnPause;
            PauseManager.Resumed += OnResume;
        }

        private void OnDestroy()
        {
            PauseManager.Paused -= OnPause;
            PauseManager.Resumed -= OnResume;
        }

        private void OnPause()
        {
            gameObject.SetActive(true);
            if (resumeButton)
                UIManager.CurrentSelectedObject = resumeButton.gameObject;
            if (_audioManager) _audioManager.PlayShow();
        }

        private void OnResume()
        {
            gameObject.SetActive(false);
            if (_audioManager) _audioManager.PlayHide();
        }
    }
}
