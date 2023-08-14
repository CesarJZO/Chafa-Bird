namespace Utilities
{
    public static class CoolerRandom
    {
        private static float Value => UnityEngine.Random.value;

        public static bool Bool() => Value >= 0.5f;

        public static bool Bool(float chance) => Value >= chance;

        public static int Int(int maxExclusive) => UnityEngine.Random.Range(0, maxExclusive);

        public static float Float() => Value;
    }
}
