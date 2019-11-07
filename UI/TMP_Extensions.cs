using UnityEngine;

namespace TMPro
{
    public static class TMP_Extensions
    {
        public static void SetTextIfNotNull(this TextMeshProUGUI textMeshProGUI, string text)
        {
            if (textMeshProGUI != null)
                textMeshProGUI.SetText(text);
        }

        public static void SetColor(this TextMeshProUGUI textMeshProGUI, Color color)
        {
            if (textMeshProGUI != null)
                textMeshProGUI.color = color;
        }

        public static void SetTextIfNotNull(this TMP_InputField inputField, string text)
        {
            if (inputField != null && inputField.text != null)
                inputField.text = text;
        }

        public static void SetColor(this TMP_InputField inputField, Color color)
        {
            if (inputField != null && inputField.textComponent != null)
                inputField.textComponent.color = color;
        }
    }
}