#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Attributes.Editor
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public sealed class TagPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType is SerializedPropertyType.String)
            {
                EditorGUI.BeginProperty(position, label, property);

                string tagValue = string.IsNullOrEmpty(property.stringValue) ? "Untagged" : property.stringValue;

                string tag = EditorGUI.TagField(position, label, tagValue);
                property.stringValue = tag;
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.HelpBox(position, "Use [TagSelector] with string fields only.", MessageType.Error);
            }
        }
    }
}
#endif
