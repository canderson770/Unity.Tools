using UnityEngine;
using VRTK;

/// <summary>
/// VRTK_InteractableObject with an optional tooltip that turns on when object is touched
/// </summary>
public class VRTK_InteractableObjectTooltip : VRTK_InteractableObject
{
    [Header("Tooltip Options")]
    public VRTK_ObjectTooltip tooltip;
    public bool turnOffOnAwake = true;
    public bool enableOnTouch = true;
    public bool disableOnUntouch = true;

    protected override void Awake()
    {
        if (tooltip != null)
        {
            if (tooltip.drawLineTo == null)
                tooltip.drawLineTo = transform;

            if (turnOffOnAwake)
                tooltip.gameObject.SetActive(false);
        }
        base.Awake();
    }

    public override void OnInteractableObjectTouched(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectTouched(e);

        if (tooltip != null && enableOnTouch)
            tooltip.gameObject.SetActive(true);
    }

    public override void OnInteractableObjectUntouched(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUntouched(e);

        if (tooltip != null && disableOnUntouch)
            tooltip.gameObject.SetActive(false);
    }
}
