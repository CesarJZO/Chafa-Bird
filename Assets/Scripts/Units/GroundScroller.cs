using Player;
using UnityEngine;

namespace Units
{
    public sealed class GroundScroller : MonoBehaviour
    {
        [SerializeField] private float speed;

        private MeshRenderer[] _meshRenderers;

        private void Awake()
        {
            _meshRenderers = GetComponentsInChildren<MeshRenderer>();

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
            foreach (MeshRenderer r in _meshRenderers)
                r.material.mainTextureOffset = Vector2.right * (Time.time * speed);
        }
    }
}
