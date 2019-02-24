using UnityEngine;

/// <summary>
/// Runs UnityEvent OnTriggerStay, Inherits from OnTrigger_Base
/// </summary>
public class OnTriggerStay_UnityEvent : OnTrigger_Base
{
    private void OnTriggerStay(Collider coll)
    {
        CheckCollider(coll);
    }
}
