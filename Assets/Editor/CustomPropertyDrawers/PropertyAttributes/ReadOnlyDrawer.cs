using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    // Makes sure Unity calculates enough space if the property is a foldOut and the foldOut is open
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight
        (
            property: property,
            includeChildren: true
        );
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Track the property changes to ensure correct behaviour
        EditorGUI.BeginProperty(position, label, property);

        // Disables UI modifcation for this property
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
        
        // Stop tracking the changes
        EditorGUI.EndProperty();
    }
}
