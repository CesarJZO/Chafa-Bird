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

        private void Start()
        {
            if (resumeButton)
            {
                resumeButton.onClick.AddListener(PauseManager.Instance.Resume);
                UIManager.CurrentSelectedObject = resumeButton.gameObject;
            }

            if (exitToTitleButton)
            {
                exitToTitleButton.onClick.AddListener(() => SceneManager.LoadScene(GameScene.MainMenu));
            }

            PauseManager.Paused += OnPause;
            PauseManager.Resumed += OnResume;

            OnResume();
        }

        private void OnPause()
        {
            gameObject.SetActive(true);
            if (resumeButton)
                UIManager.CurrentSelectedObject = resumeButton.gameObject;
        }

        private void OnResume()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            PauseManager.Paused -= OnPause;
            PauseManager.Resumed -= OnResume;
        }
    }
}
