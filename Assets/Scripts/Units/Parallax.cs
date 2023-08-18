using UnityEngine;

namespace Units
{
    public sealed class Parallax : MonoBehaviour
    {
        [SerializeField] private Transform[] layers;
        [SerializeField] private float speed;

        private void Update()
        {
            for (var i = 0; i < layers.Length; i++)
            {
                Transform layer = layers[i];
                Vector3 position = layer.position;
                float layerSpeed = speed * (i + 1);
                position.x += layerSpeed * Time.deltaTime;
                layer.position = position;
            }
        }
    }
}
