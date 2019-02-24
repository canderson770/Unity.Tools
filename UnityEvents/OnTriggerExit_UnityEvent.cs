using UnityEngine;

/// <summary>
/// Runs UnityEvent OnTriggerExit, Inherits from OnTrigger_Base
/// </summary>
public class OnTriggerExit_UnityEvent : OnTrigger_Base
{
    private void OnTriggerExit(Collider coll)
    {
        CheckCollider(coll);
    }
}
