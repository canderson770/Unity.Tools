using UnityEngine;
using UnityEditor;
using Saving;

[CustomEditor(typeof(SaveScriptableObject))]
public class SaveScriptableObject_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SaveScriptableObject myScript = (SaveScriptableObject)target;
        if (GUILayout.Button("Show Save Location"))
        {
            myScript.ShowSaveLocation();
        }
    }
}
