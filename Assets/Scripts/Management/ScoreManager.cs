using System;
using Attributes;
using Core;
using UnityEngine;

namespace Management
{
    public sealed class ScoreManager : MonoBehaviour
    {
        public event Action<uint> OnScoreUpdated;
        public static ScoreManager Instance { get; private set; }

        [SerializeField, ReadOnly] private uint score;
        [SerializeField, ReadOnly] private uint bestScore;

        public uint CurrentScore => score;
        public uint BestScore => bestScore;

        private void Awake()
        {
            Instance = this;

            bestScore = (uint)PlayerPrefs.GetInt("BestScore");
        }

        private void Start()
        {
            score = 0;
            OnScoreUpdated?.Invoke(score);
        }

        public void IncrementScore(uint amount = 1)
        {
            score += amount;
            OnScoreUpdated?.Invoke(score);
        }

        public void SaveBestScore()
        {
            if (score > bestScore)
                bestScore = score;

            PlayerPrefs.SetInt("BestScore", (int)bestScore);
        }
    }
}
