using Core;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameScene sceneOnPlay;

        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {
            if (playButton)
                playButton.onClick.AddListener(() => SceneManager.LoadScene(sceneOnPlay));
            if (quitButton)
                quitButton.onClick.AddListener(Application.Quit);

            UIManager.CurrentSelectedObject = playButton.gameObject;
        }
    }
}
