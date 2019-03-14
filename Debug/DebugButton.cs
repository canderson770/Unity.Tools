using UnityEngine;
using UnityEngine.Events;

public class DebugButton : MonoBehaviour
{
    public UnityEvent onClick;

    public void Click()
    {
        onClick.Invoke();
    }
}
