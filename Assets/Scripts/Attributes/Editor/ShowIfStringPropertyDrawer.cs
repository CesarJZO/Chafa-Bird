#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Attributes.Editor
{
    [CustomPropertyDrawer(typeof(ShowIfStringAttribute))]
    public sealed class ShowIfStringPropertyDrawer : PropertyDrawer
    {
        private SerializedProperty _conditionalProperty;
        private ShowIfStringAttribute _showIfStringAttribute;
        private string _targetValue;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _showIfStringAttribute ??= attribute as ShowIfStringAttribute;
            _conditionalProperty ??=
                property.serializedObject.FindProperty(_showIfStringAttribute!.conditionalFieldName);
            _targetValue ??= _showIfStringAttribute!.targetValue;

            if (_conditionalProperty.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, $"[ShowIfString] {_conditionalProperty.displayName} must be a string.", MessageType.Error);
                return;
            }

            bool enabled = GetConditionValue();

            bool wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (enabled)
                EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = wasEnabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (_conditionalProperty?.propertyType != SerializedPropertyType.String)
                return EditorGUI.GetPropertyHeight(property, label);

            if (GetConditionValue())
                return EditorGUI.GetPropertyHeight(property, label);

            return -EditorGUIUtility.standardVerticalSpacing;
        }

        private bool GetConditionValue()
        {
            return _conditionalProperty is not null && _conditionalProperty.stringValue == _targetValue;
        }
    }
}
#endif
