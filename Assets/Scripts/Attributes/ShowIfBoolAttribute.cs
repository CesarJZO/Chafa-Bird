using UnityEngine;

namespace Attributes
{
    public sealed class ShowIfBoolAttribute : PropertyAttribute
    {
        public readonly string conditionFieldName;

        public ShowIfBoolAttribute(string conditionFieldName)
        {
            this.conditionFieldName = conditionFieldName;
        }
    }
}
