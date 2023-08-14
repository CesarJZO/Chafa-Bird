using Units;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        public uint CurrentScore { get; private set; }

        private void Awake()
        {
            ScoreTrigger.OnPipePassed += OnPipePassed;
        }

        private void Start()
        {
            OnPipePassed(0);
        }

        private void OnDestroy()
        {
            ScoreTrigger.OnPipePassed -= OnPipePassed;
        }

        private void OnPipePassed(uint currentScore)
        {
            CurrentScore = currentScore;
            scoreText.text = currentScore.ToString();
        }

        public void ResetScore()
        {
            CurrentScore = 0;
            scoreText.text = CurrentScore.ToString();
            ScoreTrigger.ResetScore();
        }
    }
}
