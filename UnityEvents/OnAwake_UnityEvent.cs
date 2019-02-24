using UnityEngine;
using UnityEngine.Events;

namespace CustomEvents
{
    /// <summary>
    /// Runs UnityEvent on Awake
    /// </summary>
    public class OnAwake_UnityEvent : MonoBehaviour
    {
        public UnityEvent onAwake;

        private void Awake()
        {
            if (enabled) onAwake.Invoke();
        }

        /// <summary>
        /// Used to make enabled bool show in Inspector
        /// </summary>
        private void Start() { }
    }
}
