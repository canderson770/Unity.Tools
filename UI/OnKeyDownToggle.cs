using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyDownToggle : MonoBehaviour
{
    public KeyCode key = KeyCode.BackQuote;
    public GameObject toToggle;

    private void Update()
    {
        if (Input.GetKeyDown(key) && toToggle != null)
        {
            toToggle.SetActive(!toToggle.activeSelf);
        }
    }
}
