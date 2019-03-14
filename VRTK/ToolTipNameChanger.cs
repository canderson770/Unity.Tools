using UnityEngine;
using VRTK;

/// <summary>
/// Sets tooltip text to match object name
/// </summary>
public class ToolTipNameChanger : MonoBehaviour
{
    public VRTK_ObjectTooltip tooltipScript;

    protected virtual void Awake()
    {
        tooltipScript = GetComponent<VRTK_ObjectTooltip>();
        tooltipScript.displayText = transform.parent.name;
        tooltipScript.UpdateText(transform.parent.name);
    }
}
