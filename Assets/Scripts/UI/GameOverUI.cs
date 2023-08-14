using System.Collections;
using Core;
using Management;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class GameOverUI : MonoBehaviour
    {
        [SerializeField] private ScoreUI scorePanel;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private float incrementSpeed;
        [SerializeField] private TextMeshProUGUI bestText;
        [SerializeField] private Button replayButton;
        [SerializeField] private Button exitButton;

        private void Start()
        {
            replayButton.onClick.AddListener(() =>
            {
                scorePanel.ResetScore();
                SceneManager.LoadScene(GameScene.Game);
            });
            exitButton.onClick.AddListener(() => SceneManager.LoadScene(GameScene.MainMenu));

            Bird.Died += OnBirdDie;

            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Bird.Died -= OnBirdDie;
        }

        private void OnBirdDie()
        {
            bestText.text = scorePanel.CurrentScore.ToString();
            scorePanel.gameObject.SetActive(false);
            gameObject.SetActive(true);
            StartCoroutine(IncrementToScore());
        }

        private IEnumerator IncrementToScore()
        {
            uint maxScore = scorePanel.CurrentScore;
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
                yield return new WaitForSeconds(incrementSpeed);
            }
        }
    }
}
