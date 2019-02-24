using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Runs UnityEvent on Awake
/// </summary>
public class OnAwake_UnityEvent : MonoBehaviour
{
    public UnityEvent onAwake;

    private void Awake()
    {
        onAwake.Invoke();
    }
}
