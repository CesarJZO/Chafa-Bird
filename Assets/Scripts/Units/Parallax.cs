using UnityEngine;

namespace Units
{
    public sealed class Parallax : MonoBehaviour
    {
        [SerializeField] private Transform[] layers;
        [SerializeField] private float speed;
        [SerializeField] private float screenOffset;

        private void Update()
        {
            for (var i = 0; i < layers.Length; i++)
            {
                Transform layer = layers[i];
                Vector3 position = layer.position;
                float layerSpeed = speed * (i + 1);
                position.x += layerSpeed * Time.deltaTime;

                if (Mathf.Abs(position.x) > screenOffset)
                    position.x = screenOffset * -Mathf.Sign(speed);
                layer.position = position;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Vector3 position = transform.position;
            Gizmos.DrawLine(position + Vector3.left * screenOffset, position + Vector3.right * screenOffset);
        }
    }
}
