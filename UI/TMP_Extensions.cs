namespace TMPro
{
    public static class TMP_Extensions
    {
        public static void SetTextIfNotNull(this TextMeshProUGUI textMeshProGUI, string text)
        {
            if (textMeshProGUI != null)
                textMeshProGUI.SetText(text);
        }

        public static void SetTextIfNotNull(this TMP_InputField inputField, string text)
        {
            if (inputField != null && inputField.text != null)
                inputField.text = text;
        }
    }
}