#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Utilities.Editor
{
    [CustomPropertyDrawer(typeof(Range))]
    public sealed class RangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);

            SerializedProperty minProp = property.FindPropertyRelative("min");
            SerializedProperty maxProp = property.FindPropertyRelative("max");

            Rect contentRect = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            EditorGUIUtility.labelWidth = 32f;

            var minRect = new Rect(contentRect.x, contentRect.y, contentRect.width / 2 - 2, contentRect.height);
            var maxRect = new Rect(contentRect.x + contentRect.width / 2 + 2, contentRect.y, contentRect.width / 2 - 2, contentRect.height);

            EditorGUI.PropertyField(minRect, minProp, new GUIContent("Min"));
            EditorGUI.PropertyField(maxRect, maxProp, new GUIContent("Max"));

            EditorGUI.EndProperty();
        }
    }
}
#endif
