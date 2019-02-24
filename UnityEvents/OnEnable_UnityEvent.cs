using UnityEngine;
using UnityEngine.Events;

namespace CustomEvents
{
    /// <summary>
    /// Runs UnityEvent on OnEnable
    /// </summary>
    public class OnEnable_UnityEvent : MonoBehaviour
    {
        public UnityEvent onEnable;

        private void OnEnable()
        {
            onEnable.Invoke();
        }
    }
}
