using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleOnValueChangedText : MonoBehaviour
{
    private Toggle toggle;

    [Tooltip("Change text to match toggle on Start")]
    public bool changeOnStart = true;

    [Tooltip("Value to change text to when toggle is on or off")]
    public string isOnText, isOffText;

    [Tooltip("TextMeshProUGUI to be changed")]
    public List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(ChangeText);

            if (changeOnStart)
                ChangeText(toggle.isOn);
        }
    }

    /// <summary>
    /// Changes text when toggle is changed 
    /// </summary>
    private void ChangeText(bool isOn)
    {
        foreach (var text in texts)
        {
            if (isOn)
                text.SetTextIfNotNull(isOnText);
            else
                text.SetTextIfNotNull(isOffText);
        }
    }
}