using System;
using UnityEngine;

namespace Utilities
{
    [Serializable]
    public struct Range
    {
        public float min;
        public float max;

        public Range(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public float Random => UnityEngine.Random.Range(min, max);

        public float Clamp(float value) => Mathf.Clamp(value, min, max);

        public float Lerp(float t) => Mathf.Lerp(min, max, t);
    }
}
