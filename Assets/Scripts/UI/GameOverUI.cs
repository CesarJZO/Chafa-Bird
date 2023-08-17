﻿using System;
using System.Collections;
using Core;
using Management;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class GameOverUI : PanelUI
    {
        public override event Action OnShow;
        public override event Action OnHide;
        public override event Action<Button> OnButtonClick;

        [Header("Settings")]
        [SerializeField, Min(0f)] private float showDelay;
        [SerializeField] private float bestIncrementSpeed;

        [Header("Dependencies")]
        [SerializeField] private ScoreUI scorePanel;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestText;
        [SerializeField] private Button replayButton;
        [SerializeField] private Button exitButton;

        private ScoreManager _scoreManager;
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            replayButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(GameScene.Game);
                OnButtonClick?.Invoke(replayButton);
            });
            exitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(GameScene.MainMenu);
                OnButtonClick?.Invoke(exitButton);
            });

            Bird.Died += OnBirdDie;

            _scoreManager = ScoreManager.Instance;
            if (!_scoreManager)
                Debug.LogWarning("ScoreManager was not found!", this);

            _canvasGroup = GetComponent<CanvasGroup>();

            Hide();
        }

        private void OnDestroy()
        {
            Bird.Died -= OnBirdDie;
        }

        private void OnBirdDie()
        {
            _scoreManager.SaveBestScore();
            bestText.text = _scoreManager.BestScore.ToString();

            scorePanel.Hide();
            Show();
        }

        private IEnumerator IncrementToScore()
        {
            uint maxScore = _scoreManager.CurrentScore;
            uint currentScore = maxScore switch
            {
                > 15 => maxScore - 10,
                > 5 => maxScore - 5,
                _ => 0
            };
            while (currentScore < maxScore)
            {
                currentScore++;
                scoreText.text = currentScore.ToString();
                yield return new WaitForSeconds(bestIncrementSpeed);
            }
        }

        private IEnumerator ShowAfterDelay()
        {
            yield return new WaitForSeconds(showDelay);

            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            StartCoroutine(IncrementToScore());
            OnShow?.Invoke();
        }

        public override void Show()
        {
            StartCoroutine(ShowAfterDelay());
        }

        public override void Hide()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            OnHide?.Invoke();
        }
    }
}
