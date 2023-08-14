using Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public sealed class Bird : MonoBehaviour
    {
        public static event System.Action Died;

        [SerializeField] private float peakForce;
        [SerializeField] private float dieStrength;

        [SerializeField] private UnityEvent onDie;

        private Rigidbody2D _rigidbody;
        private bool _death;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            GameplayInput.OnJump += OnJumpInput;
        }

        private void OnDestroy()
        {
            GameplayInput.OnJump -= OnJumpInput;
        }

        private void OnJumpInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            float strength = peakForce - _rigidbody.velocity.y;
            _rigidbody.AddForce(Vector2.up * strength, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D()
        {
            if (_death) return;
            _death = true;

            _rigidbody.constraints = RigidbodyConstraints2D.None;
            float direction = Mathf.Sign(Random.Range(-1f, 1f));
            _rigidbody.AddForce(new Vector2(direction, 1f) * dieStrength, ForceMode2D.Impulse);

            Died?.Invoke();
            onDie?.Invoke();
        }
    }
}
