using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    private Vector3 posOffset, rotOffset;
    private float x, y, z;

    [Tooltip("Transform to match")]
    public Transform transformToMatch;

    [Tooltip("Axes to match")]
    public bool X, Y, Z;

    [Tooltip("Keep Offset or exactly match rotation")]
    public bool keepOffset = false;


    private void Awake()
    {
        if (transformToMatch == null)
        {
            Debug.LogWarning("<color=yellow> Transform to match not set! Disabling component. </color>", gameObject);
            enabled = false;
            return;
        }
        if (!X && !Y && !Z)
        {
            Debug.LogWarning("<color=yellow> Not set to match any rotations! Disabling component. </color>", gameObject);
            enabled = false;
            return;
        }

        if (keepOffset)
            rotOffset = transform.rotation.eulerAngles - transformToMatch.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        if (transformToMatch == null) return;
        if (!X && !Y && !Z) return;

        if (X)
            x = transformToMatch.rotation.eulerAngles.x;
        else
            x = transform.rotation.eulerAngles.x;

        if (Y)
            y = transformToMatch.rotation.eulerAngles.y;
        else
            y = transform.rotation.eulerAngles.y;

        if (Z)
            z = transformToMatch.rotation.eulerAngles.z;
        else
            z = transform.rotation.eulerAngles.z;


        transform.rotation = Quaternion.Euler(new Vector3(x, y, z) + rotOffset);
    }
}
