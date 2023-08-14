using System;
using Attributes;
using UnityEngine;

namespace Units
{
    public class ScoreTrigger : MonoBehaviour
    {
        public static event Action<uint> OnPipePassed;

        [SerializeField, Tag] private string birdTag;

        private uint _currentScore;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(birdTag))
                OnPipePassed?.Invoke(_currentScore);
        }
    }
}
