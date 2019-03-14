using UnityEngine;
using UnityEngine.Events;
using VRTK;

/// <summary>
///  Makes OnGrab and OnUse both run a UnityEvent instead of default actions, Overrides "VRTK_InteractableObject"
/// </summary>
public class OnGrabAndUseVRTK : VRTK_InteractableObjectTooltip
{
    private AudioSource source;

    public UnityEvent OnGrabAndUse;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        if (tooltip != null)
        {
            tooltip.SetActive(false);

            VRTK_ObjectTooltip tooltipScript = tooltip.GetComponent<VRTK_ObjectTooltip>();

            if (tooltipScript != null)
            {
                if (tooltipScript.drawLineTo == null)
                    tooltipScript.drawLineFrom = transform;
            }
        }
    }

    public override void OnInteractableObjectTouched(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectTouched(e);

        if (tooltip != null)
            tooltip.SetActive(true);
    }

    public override void OnInteractableObjectUntouched(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUntouched(e);

        if (tooltip != null)
            tooltip.SetActive(false);
    }

    /// <summary>
    /// Overrides to do an UnityEvent instead of grabbing
    /// </summary>
    public override void OnInteractableObjectGrabbed(InteractableObjectEventArgs e)
    {
        OnGrabAndUse.Invoke();

        if (source != null)
            source.Play();
    }

    /// <summary>
    /// Overrides to do an UnityEvent instead of using
    /// </summary>
    public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
    {
        OnGrabAndUse.Invoke();

        if (source != null)
            source.Play();
    }
}
