using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnToggledEvent : MonoBehaviour
{
    private Toggle toggle;

    public UnityEvent onToggledOn;
    public UnityEvent onToggledOff;

    //  used to show enabled toggle
    private void Start() { }

    private void Awake()
    {
        toggle = GetComponent<Toggle>();

        if (toggle != null)
            toggle.onValueChanged.AddListener(CheckToggle);
    }

    private void CheckToggle(bool value)
    {
        if (!enabled) return;

        if (value)
            onToggledOn.Invoke();
        else
            onToggledOff.Invoke();
    }
}
