using Core;
using Input;
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

        private void Start()
        {
            if (playButton)
                playButton.onClick.AddListener(() => SceneManager.LoadScene(sceneOnPlay));
            if (optionsPanel && optionsButton)
                optionsButton.onClick.AddListener(optionsPanel.Show);
            if (quitButton)
                quitButton.onClick.AddListener(Application.Quit);

            UIManager.CurrentSelectedObject = playButton.gameObject;
        }
    }
}
