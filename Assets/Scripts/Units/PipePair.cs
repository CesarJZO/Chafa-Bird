using Player;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PipePair : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            Bird.OnDie += OnBirdDie;
        }

        private void OnDestroy()
        {
            Bird.OnDie -= OnBirdDie;
        }

        private void Start()
        {
            _rigidbody.velocity = Vector2.left * speed;
            Destroy(gameObject, lifeTime);
        }

        private void OnBirdDie()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
