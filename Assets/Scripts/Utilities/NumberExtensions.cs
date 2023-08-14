using UnityEngine;

namespace Utilities
{
    public static class NumberExtensions
    {
        public static float Clamp01(this float value)
        {
            return Mathf.Clamp01(value);
        }

        public static float Clamp(this float value, float min, float max)
        {
            return Mathf.Clamp(value, min, max);
        }

        public static int ClampMin(this int value, int min)
        {
            return Mathf.Clamp(value, min, int.MaxValue);
        }

        public static int ClampMax(this int value, int max)
        {
            return Mathf.Clamp(value, int.MinValue, max);
        }

        public static int Clamp(this int value, int min, int max)
        {
            return Mathf.Clamp(value, min, max);
        }

        public static float Ceil(this float value)
        {
            return Mathf.Ceil(value);
        }

        public static float Floor(this float value)
        {
            return Mathf.Floor(value);
        }

        public static float Round(this float value)
        {
            return Mathf.Round(value);
        }

        public static float Sign(this float value)
        {
            return Mathf.Sign(value);
        }
    }
}
