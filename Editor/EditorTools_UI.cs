using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace CustomEditors
{
    public class EditorTools_UI
    {
        [MenuItem("Tools/UI/Buttons/Set Nav to None In Children", false, 1)]
        public static void UINavigationNone()
        {
            if (Selection.activeGameObject == null) return;
            Selectable[] selectables = Selection.activeGameObject.GetComponentsInChildren<Selectable>(true);

            Navigation nav = new Navigation();
            nav.mode = Navigation.Mode.None;

            int buttonAmount = 0;
            foreach (Selectable selectable in selectables)
            {
                selectable.navigation = nav;
                buttonAmount++;
            }
            Debug.Log("Navigation set for " + buttonAmount + " buttons");
        }

        [MenuItem("Tools/UI/Buttons/Set Fade Duration to Zero In Children", false, 1)]
        public static void FadeDurationZero()
        {
            if (Selection.activeGameObject == null) return;

            Button[] buttons = Selection.activeGameObject.GetComponentsInChildren<Button>(true);

            int buttonAmount = 0;
            foreach (Button button in buttons)
            {
                ColorBlock colors = button.colors;
                colors.fadeDuration = 0;
                button.colors = colors;
                buttonAmount++;
            }
            Debug.Log("Fade Duration set for " + buttonAmount + " buttons");
        }
    }
}
