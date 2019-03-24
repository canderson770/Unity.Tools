using UnityEngine;
using UnityEditor;
using VRTK;

namespace CustomEditors
{
    public class EditorTools_VRTK
    {
        [MenuItem("Tools/VRTK/Enable all VRTK_UICanvases In Children", false, 11)]
        public static void EnableVRTK_UICanvas()
        {
            if (Selection.activeGameObject == null) return;

            int canvasAmount = 0;
            VRTK_UICanvas[] components = Selection.activeGameObject.GetComponentsInChildren<VRTK_UICanvas>(true);
            foreach (VRTK_UICanvas canvas in components)
            {
                canvas.enabled = true;
                canvasAmount++;
            }
            Debug.Log(canvasAmount + " VRTK_UICanvases enabled");

            int amount = 0;
            ToggleVRTK_UICanvasInParent[] scripts = Selection.activeGameObject.GetComponentsInChildren<ToggleVRTK_UICanvasInParent>(true);
            foreach (ToggleVRTK_UICanvasInParent canvas in scripts)
            {
                canvas.enabled = true;
                amount++;
            }
            Debug.Log(amount + " ToggleVRTK_UICanvasInParent scripts enabled");
        }

        [MenuItem("Tools/VRTK/Disable all VRTK_UICanvases In Children", false, 12)]
        public static void DisbleVRTK_UICanvas()
        {
            if (Selection.activeGameObject == null) return;

            int canvasAmount = 0;
            VRTK_UICanvas[] components = Selection.activeGameObject.GetComponentsInChildren<VRTK_UICanvas>(true);
            foreach (VRTK_UICanvas canvas in components)
            {
                canvas.enabled = false;
                canvasAmount++;
            }
            Debug.Log(canvasAmount + " VRTK_UICanvases disabled");

            int amount = 0;
            ToggleVRTK_UICanvasInParent[] scripts = Selection.activeGameObject.GetComponentsInChildren<ToggleVRTK_UICanvasInParent>(true);
            foreach (ToggleVRTK_UICanvasInParent canvas in scripts)
            {
                canvas.enabled = false;
                amount++;
            }
            Debug.Log(amount + " ToggleVRTK_UICanvasInParent scripts disabled");
        }

        [MenuItem("Tools/VRTK/Copy to all Haptics in Scene", false, 0)]
        public static void CopyControllerHaptics()
        {
            if (Selection.activeGameObject == null) return;
            VRTK_InteractHaptics hapticsToCopy = Selection.activeGameObject.GetComponent<VRTK_InteractHaptics>();

            object[] objs = Object.FindObjectsOfType(typeof(VRTK_InteractHaptics));
            foreach (VRTK_InteractHaptics haptics in objs)
            {
                haptics.clipOnTouch = hapticsToCopy.clipOnTouch;
                haptics.strengthOnTouch = hapticsToCopy.strengthOnTouch;
                haptics.durationOnTouch = hapticsToCopy.durationOnTouch;
                haptics.intervalOnTouch = hapticsToCopy.intervalOnTouch;

                haptics.clipOnGrab = hapticsToCopy.clipOnGrab;
                haptics.strengthOnGrab = hapticsToCopy.strengthOnGrab;
                haptics.durationOnGrab = hapticsToCopy.durationOnGrab;
                haptics.intervalOnGrab = hapticsToCopy.intervalOnGrab;

                haptics.clipOnUse = hapticsToCopy.clipOnUse;
                haptics.strengthOnUse = hapticsToCopy.strengthOnUse;
                haptics.durationOnUse = hapticsToCopy.durationOnUse;
                haptics.intervalOnUse = hapticsToCopy.intervalOnUse;
            }
        }
    }
}
