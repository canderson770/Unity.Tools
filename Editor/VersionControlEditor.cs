using UnityEngine;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEditor.Callbacks;
using VCEditorSettings;

namespace CustomEditors
{
    /// <summary>
    /// Version Control shortcuts
    /// </summary>
    public class VersionControlEditor : Editor
    {
        private const string control = "%", alt = "&", shift = "#";

        [MenuItem("Tools/Version Control/Check Out and Lock Selection " + alt + "l", false, 1000)]
        public static void CheckOutSelection()
        {
            CheckOut(true);
        }

        /// <summary>
        /// Checks out selection, Optional parameter to also lock selection
        /// </summary>
        public static void CheckOut(bool doLock = true)
        {
            if (!Provider.isActive) return;
            Provider.Checkout(Provider.GetAssetListFromSelection(), CheckoutMode.Both);
            if (doLock) Provider.Lock(Provider.GetAssetListFromSelection(), true);
        }

        [MenuItem("Tools/Version Control/Revert All Unchanged " + alt + "r", false, 1010)]
        public static void RevertUnchanged()
        {
            if (!Provider.isActive) return;
            var selection = Selection.objects;
            Selection.objects = Resources.FindObjectsOfTypeAll<Object>();
            Provider.Revert(Provider.GetAssetListFromSelection(), RevertMode.Unchanged);
            Selection.objects = selection;
        }

        [OnOpenAsset(1)]
        public static bool CheckOutFileOnOpen(int instanceID, int line)
        {
            //  auto check out
            if (VCSettings.autoCheckOut)
            {
                var item = EditorUtility.InstanceIDToObject(instanceID);
                Selection.activeObject = item;

                //  limit to scripts
                if (VCSettings.onlyScripts)
                {
                    var path = AssetDatabase.GetAssetPath(instanceID);
                    var type = AssetDatabase.GetMainAssetTypeAtPath(path);

                    //  check out
                    if (type == typeof(MonoScript))
                        CheckOut(VCSettings.autoLock);
                }
                //  any file
                else
                {
                    //  check out
                    CheckOut(VCSettings.autoLock);
                }
            }
            return false; // we did not handle the open
        }
    }
}

namespace VCEditorSettings
{
    public class VCSettings : EditorWindow
    {
        public static bool autoCheckOut = true;
        public static bool autoLock = false;
        public static bool onlyScripts = true;

        /// <summary>
        /// Opens window
        /// </summary>
        [MenuItem("Tools/Version Control/Auto Check Out Settings", false, 3000)]
        public static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(VCSettings), false, "Auto Check Out Settings");
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void OnEnable()
        {
            if (EditorPrefs.HasKey("AutoCheckOut"))
                autoCheckOut = EditorPrefs.GetBool("AutoCheckOut");
            else
                EditorPrefs.SetBool("AutoCheckOut", autoCheckOut);

            if (EditorPrefs.HasKey("AutoLock"))
                autoLock = EditorPrefs.GetBool("AutoLock");
            else
                EditorPrefs.SetBool("AutoLock", autoLock);

            if (EditorPrefs.HasKey("OnlyScripts"))
                onlyScripts = EditorPrefs.GetBool("OnlyScripts");
            else
                EditorPrefs.SetBool("OnlyScripts", onlyScripts);
        }

        /// <summary>
        /// GUI for window
        /// </summary>
        private void OnGUI()
        {
            GUILayout.Label("Auto Check Out Settings", EditorStyles.boldLabel);

            //  auto check out
            autoCheckOut = EditorGUILayout.Toggle(new GUIContent("Auto Check Out Files", "Automatically check out a file when it is opened"), autoCheckOut);
            EditorPrefs.SetBool("AutoCheckOut", autoCheckOut);

            //  auto lock
            autoLock = EditorGUILayout.Toggle(new GUIContent("Auto Lock Files", "Automatically lock a file when it is opened."), autoLock);
            EditorPrefs.SetBool("AutoLock", autoLock);

            //  only scripts
            onlyScripts = EditorGUILayout.Toggle(new GUIContent("Scripts Only", "If true, Auto Check Out and Auto Lock only work on scripts. If false, any asset will be automatically checked out/locked when opened."), onlyScripts);
            EditorPrefs.SetBool("OnlyScripts", onlyScripts);
        }
    }
}
