using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CustomEditors
{
    public class RemoveComponentsEditor
    {
        [MenuItem("Tools/Remove/Convert to Props (All of the below)", false, 51)]
        public static void ConvertToProps()
        {
            if (Selection.activeGameObject == null) return;

            if (EditorUtility.DisplayDialog("Warning!",
                "This will remove many components on " + Selection.activeGameObject.name + ". Continue?", "Yes", "No"))
            {
                RemoveScripts();
                RemoveLights();
                RemoveGraphicRaycasters();
                RemoveRigidbodies();
                RemoveAudioSources();
                RemoveCameras();
                RemoveAnimators();
            }
        }

        [MenuItem("Tools/Remove/Remove All Scripts In Children", false, 111)]
        public static void RemoveScripts()
        {
            if (Selection.activeGameObject == null) return;

            MonoBehaviour[] scripts = Selection.activeGameObject.GetComponentsInChildren<MonoBehaviour>(true);
            List<MonoBehaviour> s = new List<MonoBehaviour>();
            foreach (var script in scripts)
            {
                if (!(script is Graphic) && !(script is UIBehaviour))
                {
                    s.Add(script);
                }
            }
            DestroyObjects(s.ToArray());
        }

        [MenuItem("Tools/Remove/Remove All Lights In Children", false, 111)]
        public static void RemoveLights()
        {
            if (Selection.activeGameObject == null) return;
            Light[] components = Selection.activeGameObject.GetComponentsInChildren<Light>(true);
            DestroyObjects(components);
        }

        [MenuItem("Tools/Remove/Remove All GraphicRaycasters In Children", false, 111)]
        public static void RemoveGraphicRaycasters()
        {
            if (Selection.activeGameObject == null) return;
            GraphicRaycaster[] components = Selection.activeGameObject.GetComponentsInChildren<GraphicRaycaster>(true);
            DestroyObjects(components);
        }

        [MenuItem("Tools/Remove/Remove All AudioSources In Children", false, 111)]
        public static void RemoveAudioSources()
        {
            if (Selection.activeGameObject == null) return;
            AudioSource[] components = Selection.activeGameObject.GetComponentsInChildren<AudioSource>(true);
            DestroyObjects(components);
        }

        [MenuItem("Tools/Remove/Remove All Rigidbodies In Children", false, 111)]
        public static void RemoveRigidbodies()
        {
            if (Selection.activeGameObject == null) return;

            Joint[] joints = Selection.activeGameObject.GetComponentsInChildren<Joint>(true);
            Rigidbody[] rigidbodies = Selection.activeGameObject.GetComponentsInChildren<Rigidbody>(true);

            DestroyObjects(joints);
            DestroyObjects(rigidbodies);
        }

        [MenuItem("Tools/Remove/Remove All Cameras In Children", false, 111)]
        public static void RemoveCameras()
        {
            if (Selection.activeGameObject == null) return;

            //Debug.Log(typeof(Camera).IsDefined(typeof(RequireComponent), false));

            FlareLayer[] flareLayers = Selection.activeGameObject.GetComponentsInChildren<FlareLayer>(true);
            GUILayer[] guiLayers = Selection.activeGameObject.GetComponentsInChildren<GUILayer>(true);
            AudioListener[] audioListeners = Selection.activeGameObject.GetComponentsInChildren<AudioListener>(true);
            Camera[] cameras = Selection.activeGameObject.GetComponentsInChildren<Camera>(true);

            DestroyObjects(flareLayers);
            DestroyObjects(guiLayers);
            DestroyObjects(audioListeners);
            DestroyObjects(cameras);
        }

        [MenuItem("Tools/Remove/Remove All Animators In Children", false, 111)]
        public static void RemoveAnimators()
        {
            if (Selection.activeGameObject == null) return;
            Animator[] components = Selection.activeGameObject.GetComponentsInChildren<Animator>(true);
            DestroyObjects(components);
        }

        [MenuItem("Tools/Remove/Remove All Colliders In Children", false, 11)]
        public static void RemoveColliders()
        {
            if (Selection.activeGameObject == null) return;
            Collider[] components = Selection.activeGameObject.GetComponentsInChildren<Collider>(true);
            DestroyObjects(components);
        }

        /// <summary>
        /// Destroys list of Objects
        /// </summary>
        private static void DestroyObjects(Object[] components)
        {
            int numComponentsRemoved = 0;
            foreach (Object component in components)
            {
                Undo.DestroyObjectImmediate(component);
                numComponentsRemoved++;
            }
            if (components.Length > 0)
                Debug.Log(string.Format("{0} {1}(s) removed.", numComponentsRemoved, components[0].GetType()));
        }
    }
}
