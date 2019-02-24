using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Runs UnityEvent on OnDisable
/// </summary>
public class OnDisable_UnityEvent : MonoBehaviour
{
    public UnityEvent onDisable;

    private void OnDisable()
    {
        onDisable.Invoke();
    }
}
