using Attributes;
using UnityEngine;

namespace Camera
{
    public sealed class CameraShaker : MonoBehaviour
    {
        [SerializeField] private float shakeDuration;
        [SerializeField] private float shakeMagnitude;
        [SerializeField] private float dampingSpeed;
        [SerializeField] private float speed;

        [SerializeField, Caller] private string test;

        private Vector3 _initialPosition;
        private float _shakeDuration;
        private float _shakeMagnitude;

        private void Awake()
        {
            _initialPosition = transform.localPosition;
        }

        private void Update()
        {
            if (_shakeDuration > 0)
            {
                transform.localPosition = Vector3.Lerp(
                    transform.localPosition,
                    _initialPosition + Random.insideUnitSphere * _shakeMagnitude,
                    Time.deltaTime * speed
                );
                _shakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                _shakeDuration = 0f;
                transform.localPosition = Vector3.Lerp(
                    transform.localPosition,
                    _initialPosition,
                    Time.deltaTime * speed
                );
            }
        }

        public void Shake()
        {
            _shakeDuration = shakeDuration;
            _shakeMagnitude = shakeMagnitude;
        }
    }
}
