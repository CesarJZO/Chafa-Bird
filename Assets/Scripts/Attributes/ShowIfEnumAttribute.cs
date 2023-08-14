using UnityEngine;

namespace Attributes
{
    public sealed class ShowIfEnumAttribute : PropertyAttribute
    {
        public readonly string conditionalFieldName;
        public readonly int targetValue;

        public ShowIfEnumAttribute(string conditionalFieldName, int targetValue)
        {
            this.conditionalFieldName = conditionalFieldName;
            this.targetValue = targetValue;
        }
    }
}
