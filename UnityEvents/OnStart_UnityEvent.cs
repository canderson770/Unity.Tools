using UnityEngine;
using UnityEngine.Events;

namespace CustomEvents
{
    /// <summary>
    /// Runs UnityEvent on Start
    /// </summary>
    public class OnStart_UnityEvent : MonoBehaviour
    {
        public UnityEvent onStart;

        private void Start()
        {
            onStart.Invoke();
        }
    }
}
