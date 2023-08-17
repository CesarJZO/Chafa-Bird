using Attributes;
using Management;
using UnityEngine;

namespace Units
{
    public class ScoreTrigger : MonoBehaviour
    {
        [SerializeField, Tag] private string birdTag;

        private ScoreManager _scoreManager;

        private void Start()
        {
            _scoreManager = ScoreManager.Instance;

            if (!_scoreManager)
                Debug.LogWarning("ScoreManager was not found!", this);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(birdTag))
                _scoreManager.IncrementScore();
        }
    }
}
