using System;
using Attributes;
using UnityEngine;

namespace Management
{
    public sealed class ScoreManager : MonoBehaviour
    {
        private const string BestScoreKey = "BestScore";
        public event Action<uint> OnScoreUpdated;
        public static ScoreManager Instance { get; private set; }

        [SerializeField, ReadOnly] private uint score;
        [SerializeField, ReadOnly] private uint bestScore;

        public uint CurrentScore => score;
        public uint BestScore => bestScore;

        private void Awake()
        {
            Instance = this;

            bestScore = (uint)PlayerPrefs.GetInt(BestScoreKey);
        }

        private void Start()
        {
            score = 0;
            OnScoreUpdated?.Invoke(score);
        }

        public void IncrementScore(uint amount = 1)
        {
            score += amount;

            if (score > bestScore)
                SaveBestScore();

            OnScoreUpdated?.Invoke(score);
        }

        private void SaveBestScore()
        {
            bestScore = score;

            PlayerPrefs.SetInt(BestScoreKey, (int)bestScore);
        }
    }
}
