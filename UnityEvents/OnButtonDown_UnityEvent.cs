using UnityEngine;
using UnityEngine.Events;

public class OnButtonDown_UnityEvent : MonoBehaviour
{
    public string button = "Submit";
    public UnityEvent onButtonDown;

    private void Update()
    {
        if (!string.IsNullOrEmpty(button) && Input.GetButtonDown(button))
            onButtonDown.Invoke();
    }
}
