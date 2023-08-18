using Audio;
using Core;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameScene sceneOnPlay;
        [SerializeField] private OptionsUI optionsPanel;

        [SerializeField] private Button playButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button quitButton;

        private UIAudioManager _audioManager;

        private void Start()
        {
            _audioManager = UIAudioManager.Instance;
            if (playButton)
                playButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(sceneOnPlay);
                    if (_audioManager) _audioManager.PlaySubmitAlt();
                });
            if (optionsPanel && optionsButton)
                optionsButton.onClick.AddListener(() =>
                {
                    optionsPanel.Show();
                    if (_audioManager) _audioManager.PlaySelect();
                });
            if (quitButton)
                quitButton.onClick.AddListener(() =>
                {
                    Application.Quit();
                    if (_audioManager) _audioManager.PlaySelect();
                });

            UIManager.CurrentSelectedObject = playButton.gameObject;
        }
    }
}
