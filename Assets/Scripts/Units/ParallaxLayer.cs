using System;
using UnityEngine;

namespace Units
{
    public sealed class ParallaxLayer : MonoBehaviour
    {
        [SerializeField] private float width;

        private float _startPosition;

        private void Start()
        {
            _startPosition = transform.position.x;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            if (Mathf.Abs(position.x - _startPosition) > width)
                transform.position = new Vector3(_startPosition, position.y, position.z);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Vector3 position = transform.position;
            Gizmos.DrawLine(position + Vector3.left * (width / 2f), position + Vector3.right * (width / 2f));
        }
    }
}
