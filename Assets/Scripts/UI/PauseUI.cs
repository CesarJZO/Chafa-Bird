using System;
using Core;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class PauseUI : PanelUI
    {
        public override event Action OnShow;
        public override event Action OnHide;
        public override event Action<Button> OnButtonClick;

        [SerializeField] private Button resumeButton;
        [SerializeField] private Button exitToTitleButton;

        private void Start()
        {
            if (resumeButton)
            {
                resumeButton.onClick.AddListener(() =>
                {
                    PauseManager.Instance.Resume();
                    OnButtonClick?.Invoke(resumeButton);
                });
                UIManager.CurrentSelectedObject = resumeButton.gameObject;
            }

            if (exitToTitleButton)
            {
                exitToTitleButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(GameScene.MainMenu);
                    OnButtonClick?.Invoke(exitToTitleButton);
                });
            }

            PauseManager.Paused += OnPause;
            PauseManager.Resumed += OnResume;

            OnResume();
        }

        private void OnPause()
        {
            Show();
            if (resumeButton)
                UIManager.CurrentSelectedObject = resumeButton.gameObject;
        }

        private void OnResume()
        {
            Hide();
        }

        private void OnDestroy()
        {
            PauseManager.Paused -= OnPause;
            PauseManager.Resumed -= OnResume;
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            OnShow?.Invoke();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
    }
}
