using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DebugButton))]
public class DebugButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DebugButton myScript = (DebugButton)target;
        if (GUILayout.Button("Debug Button"))
        {
            myScript.Click();
        }
    }
}
