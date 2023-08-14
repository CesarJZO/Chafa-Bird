using Units;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

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
            scoreText.text = currentScore.ToString("D2");
        }
    }
}
