using System;
using Attributes;
using UnityEngine;

namespace Units
{
    public class ScoreTrigger : MonoBehaviour
    {
        public static event Action<uint> OnPipePassed;

        [SerializeField, Tag] private string birdTag;

        private static uint _currentScore;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(birdTag))
                OnPipePassed?.Invoke(++_currentScore);
        }

        public static void ResetScore()
        {
            _currentScore = 0;
        }
    }
}
