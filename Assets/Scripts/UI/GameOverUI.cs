using System.Collections;
using Audio;
using Core;
using Management;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class GameOverUI : MonoBehaviour
    {
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

        private UIAudioManager _audioManager;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            Hide();

            _audioManager = UIAudioManager.Instance;

            replayButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(GameScene.Game);
                if (_audioManager) _audioManager.PlaySelect();
            });
            exitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(GameScene.MainMenu);
                if (_audioManager) _audioManager.PlaySelect();
            });

            Bird.Died += OnBirdDie;

            _scoreManager = ScoreManager.Instance;
            if (!_scoreManager)
                Debug.LogWarning("ScoreManager was not found!", this);
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
            if (_audioManager) _audioManager.PlayShow();

            StartCoroutine(IncrementToScore());
        }

        public void Show()
        {
            StartCoroutine(ShowAfterDelay());
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            if (_audioManager) _audioManager.PlayHide();
        }
    }
}
