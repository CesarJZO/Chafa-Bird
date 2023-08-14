using Player;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PipePair : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            Bird.Died += OnBirdDie;
        }

        private void OnDestroy()
        {
            Bird.Died -= OnBirdDie;
        }

        private void Start()
        {
            _rigidbody.velocity = Vector2.left * speed;
        }

        private void OnBirdDie()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
