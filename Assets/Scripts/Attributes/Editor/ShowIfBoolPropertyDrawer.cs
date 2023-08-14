#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Attributes.Editor
{
    [CustomPropertyDrawer(typeof(ShowIfBoolAttribute))]
    public sealed class ShowIfBoolPropertyDrawer : PropertyDrawer
    {
        private SerializedProperty _conditionalProperty;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var showIfBool = attribute as ShowIfBoolAttribute;

            _conditionalProperty ??= property.serializedObject.FindProperty(showIfBool!.conditionFieldName);

            if (_conditionalProperty.propertyType != SerializedPropertyType.Boolean)
            {
                EditorGUI.HelpBox(position, $"[ShowIfBool] {_conditionalProperty.displayName} must be a bool.", MessageType.Error);
                return;
            }

            bool enabled = GetConditionValue(showIfBool, property);

            bool wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (enabled)
                EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = wasEnabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var showIf = attribute as ShowIfBoolAttribute;

            if (_conditionalProperty?.propertyType != SerializedPropertyType.Boolean)
                return EditorGUI.GetPropertyHeight(property, label);

            bool enabled = GetConditionValue(showIf, property);

            if (enabled)
                return EditorGUI.GetPropertyHeight(property, label);

            return -EditorGUIUtility.standardVerticalSpacing;
        }

        private static bool GetConditionValue(ShowIfBoolAttribute showIfBool, SerializedProperty property)
        {
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIfBool.conditionFieldName);
            return conditionProperty is not null && conditionProperty.boolValue;
        }
    }
}
#endif
