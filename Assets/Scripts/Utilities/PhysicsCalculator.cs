using UnityEngine;

namespace Utilities
{
    public static class PhysicsCalculator
    {
        public static float JumpStrength(float gravityScale, float mass, float jumpHeight)
        {
            float gravityScaled = Physics2D.gravity.y * gravityScale;
            return Mathf.Sqrt(-2f * gravityScaled * jumpHeight) * mass;
        }

        public static float JumpStrength(Rigidbody2D rigidbody, float jumpHeight)
        {
            return JumpStrength(rigidbody.gravityScale, rigidbody.mass, jumpHeight);
        }
    }
}
