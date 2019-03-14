using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MatchRotation))]
public class MatchRotationEditor : Editor
{
    private MatchRotation script;
    private SerializedProperty m_script;
    private const int width = 50;

    private void OnEnable()
    {
        // Setup the SerializedProperties.
        script = (MatchRotation)target;
        m_script = serializedObject.FindProperty("m_Script");
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();

        //  Show default script
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(m_script, true, new GUILayoutOption[0]);
        EditorGUI.EndDisabledGroup();

        //  variables
        EditorGUILayout.PropertyField(serializedObject.FindProperty("transformToMatch"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("keepOffset"));

        //  axes group
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Axes:", EditorStyles.label, GUILayout.MaxWidth(width));
        script.X = EditorGUILayout.ToggleLeft("X", script.X, GUILayout.Width(width));
        script.Y = EditorGUILayout.ToggleLeft("Y", script.Y, GUILayout.Width(width));
        script.Z = EditorGUILayout.ToggleLeft("Z", script.Z, GUILayout.Width(width));
        EditorGUILayout.EndHorizontal();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
}
