using System;
using Player;
using Settings;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PipePair : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private SpriteRenderer topSpriteRenderer;
        [SerializeField] private SpriteRenderer bottomSpriteRenderer;
        [SerializeField] private PipeSprites pipeSprites;

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

        public void SetColor(PipeColor pipeColor)
        {
            try
            {
                Sprite pipeSprite = pipeSprites.GetSprite(pipeColor);
                topSpriteRenderer.sprite = pipeSprite;
                bottomSpriteRenderer.sprite = pipeSprite;
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("Something is null in PipePair.", this);
            }
        }
    }
}
