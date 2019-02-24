using UnityEngine;

namespace CustomEvents
{
    /// <summary>
    /// Runs UnityEvent OnTriggerEnter, Inherits from OnTrigger_Base
    /// </summary>
    public class OnTriggerEnter_UnityEvent : OnTrigger_Base
    {
        private void OnTriggerEnter(Collider coll)
        {
            CheckCollider(coll);
        }
    }
}
