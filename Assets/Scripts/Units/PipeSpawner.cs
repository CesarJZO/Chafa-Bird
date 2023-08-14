using Player;
using UnityEngine;

namespace Units
{
    public sealed class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private PipePair pipePair;
        [SerializeField] private float spawnRate;
        [SerializeField] private float heightOffsetRange;

        private void Awake()
        {
            Bird.OnDie += OnBirdDie;
        }

        private void OnDestroy()
        {
            Bird.OnDie -= OnBirdDie;
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
            Instantiate(pipePair, transform.position + Vector3.up * heightOffset, Quaternion.identity);
        }
    }
}
