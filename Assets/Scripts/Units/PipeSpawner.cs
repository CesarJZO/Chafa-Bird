﻿using Player;
using Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units
{
    public sealed class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private PipeColor pipeColor;
        [SerializeField] private PipePair pipePair;
        [SerializeField] private float spawnRate;
        [SerializeField] private float heightOffsetRange;

        private void Awake()
        {
            Bird.Died += OnBirdDie;
        }

        private void OnDestroy()
        {
            Bird.Died -= OnBirdDie;
        }

        private void OnBirdDie()
        {
            CancelInvoke(nameof(SpawnPipe));
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnPipe), 0f, spawnRate);
        }

        private void SpawnPipe()
        {
            float heightOffset = Random.Range(-heightOffsetRange, heightOffsetRange);
            PipePair instance = Instantiate(
                pipePair,
                transform.position + Vector3.up * heightOffset,
                Quaternion.identity
            );
            instance.SetColor(pipeColor);
        }
    }
}
