using UnityEngine;
using UnityEngine.Events;

public class OnKeyDown_UnityEvent : MonoBehaviour
{
    public KeyCode key = KeyCode.Return;
    public UnityEvent onKeyDown;

    private void Update()
    {
        if (Input.GetKeyDown(key))
            onKeyDown.Invoke();
    }
}
