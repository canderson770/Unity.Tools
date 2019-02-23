using UnityEditor;

public class ConsoleEditor
{
    private const string control = "%", alt = "&", shift = "#", hotkey = "c";

    [MenuItem("Custom Editor Tools/Tools/Clear Console " + alt + hotkey, false, int.MaxValue)]
    public static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries,UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }
}
