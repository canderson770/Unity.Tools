using UnityEngine;
using VRTK;

/// <summary>
/// Plays sound effect when teleporting, Overrides VRTK_HeightAdjustTeleport
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class TeleportSound : VRTK_HeightAdjustTeleport
{
    private AudioSource source;

    protected virtual void Start()
    {
        source = GetComponent<AudioSource>();
    }

    protected override Vector3 GetNewPosition(Vector3 tipPosition, Transform target, bool returnOriginalPosition)
    {
        //play sound
        if (source != null) source.Play();

        //base
        Vector3 basePosition = base.GetNewPosition(tipPosition, target, returnOriginalPosition);
        if (!returnOriginalPosition)
        {
            basePosition.y = GetTeleportY(target, tipPosition);
        }
        return basePosition;
    }
}
