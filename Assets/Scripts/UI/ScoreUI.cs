using Management;
using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start()
        {
            if (!ScoreManager.Instance)
            {
                Debug.LogWarning("ScoreManager was not found!", this);
                return;
            }

            ScoreManager.Instance.OnScoreUpdated += OnScoreUpdated;

            OnScoreUpdated(0);
        }

        private void OnDestroy()
        {
            ScoreManager.Instance.OnScoreUpdated -= OnScoreUpdated;
        }

        private void OnScoreUpdated(uint currentScore)
        {
            scoreText.text = currentScore.ToString();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
