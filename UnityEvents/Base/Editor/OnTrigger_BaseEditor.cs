using UnityEditorInternal;
using UnityEngine;
using UnityEditor;
using CustomEvents;

[CustomEditor(typeof(OnTrigger_Base), true)]
public class OnTrigger_BaseEditor : Editor
{
    private OnTrigger_Base script;
    private SerializedProperty m_Script;

    private void OnEnable()
    {
        script = (OnTrigger_Base)target;
        m_Script = serializedObject.FindProperty("m_Script");
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();

        //  Show default script
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(m_Script, true, new GUILayoutOption[0]);
        EditorGUI.EndDisabledGroup();

        //  Settings
        script.checksFor = (OnTrigger_Base.Check)EditorGUILayout.EnumPopup("Collides With:", script.checksFor);
        DrawSettings();

        //  UnityEvent
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onTrigger"), true);

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }

    /// <summary>
    /// Draws field based on current setting to check for
    /// </summary>
    public void DrawSettings()
    {
        if (script.checksFor == OnTrigger_Base.Check.Layer)
        {
            Undo.RecordObject(script, "Changed Layer");
            script.layers = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(EditorGUILayout.MaskField("Layers:",
                InternalEditorUtility.LayerMaskToConcatenatedLayersMask(script.layers), InternalEditorUtility.layers));
        }
        else if (script.checksFor == OnTrigger_Base.Check.Tag)
        {
            Undo.RecordObject(script, "Changed Tag");
            script.tagName = EditorGUILayout.TagField("Tag:", script.tagName);
        }
        else if (script.checksFor == OnTrigger_Base.Check.Name)
        {
            Undo.RecordObject(script, "Changed Name");
            script.nameContains = EditorGUILayout.TextField("Name Contains:", script.nameContains).Trim();
        }
    }
}
