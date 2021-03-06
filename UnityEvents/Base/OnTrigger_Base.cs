using UnityEngine;
using UnityEngine.Events;

namespace CustomEvents
{
    /// <summary>
    /// Base class for other Trigger UnityEvents scripts
    /// </summary>
    public abstract class OnTrigger_Base : MonoBehaviour
    {
        public enum Check { Layer, Tag, Name, }
        public Check checksFor;

        public string nameContains;
        public LayerMask layers;
        public string tagName = "Untagged";

        public UnityEvent onTrigger;

        /// <summary>
        /// Run UnityEvent if collider matches settings
        /// </summary>
        protected void CheckCollider(Collider coll)
        {
            if (!enabled) return;

            switch (checksFor)
            {
                case Check.Name:
                    if (!string.IsNullOrEmpty(nameContains) && coll.gameObject.name.Contains(nameContains))
                        onTrigger.Invoke();
                    break;
                case Check.Layer:
                    if (layers == (layers | (1 << coll.gameObject.layer)))
                        onTrigger.Invoke();
                    break;
                case Check.Tag:
                    if (!string.IsNullOrEmpty(tagName) && coll.gameObject.CompareTag(tagName))
                        onTrigger.Invoke();
                    break;
            }
        }


        /// <summary>
        /// Used to make enabled bool show in Inspector
        /// </summary>
        protected void Start() { }
    }
}
