using Player;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class GroundScroller : MonoBehaviour
    {
        [SerializeField] private float speed;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();

            Bird.OnDie += OnBirdDie;
        }

        private void OnDestroy()
        {
            Bird.OnDie -= OnBirdDie;
        }

        private void OnBirdDie()
        {
            enabled = false;
        }

        private void Update()
        {
            _meshRenderer.material.mainTextureOffset = Vector2.right * (Time.time * speed);
        }
    }
}
