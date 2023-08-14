using UnityEngine;

namespace Utilities
{
    public static class Ease
    {
        public static float InOutSine(float t)
        {
            return -0.5f * (Mathf.Cos(Mathf.PI * t) - 1);
        }
    }
}
