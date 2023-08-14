using Attributes;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class DestroyTrigger : MonoBehaviour
    {
        [SerializeField, Tag] private new string tag;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(tag))
                Destroy(other.gameObject);
        }
    }
}
