using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    private Vector3 posOffset;
    private Vector3 rotOffset;

    [Tooltip("Transform to match")]
    public Transform transformToMatch;

    [Tooltip("Should match position?")]
    public bool matchPosition = true;

    [Tooltip("Should keep starting offset or exactly match position?")]
    public bool keepOffsetPos = false;

    [Space(10)]
    [Tooltip("Should match rotation?")]
    public bool matchRotation = false;

    [Tooltip("Should keep starting offset or exactly match rotation?")]
    public bool keepOffsetRot = false;


    private void Awake()
    {
        if (transformToMatch == null)
        {
            Debug.LogWarning("<color=yellow> Transform to match not set! </color>", gameObject);
            return;
        }

        if (!matchPosition && !matchRotation)
        {
            Debug.LogWarning("<color=yellow> Match position and rotation are both disabled. Should probably disable this component instead </color>", gameObject);
            return;
        }

        if (keepOffsetPos)
            posOffset = transform.position - transformToMatch.position;

        if (keepOffsetRot)
            rotOffset = transform.rotation.eulerAngles - transformToMatch.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        if (transformToMatch == null) return;
        if (!matchPosition && !matchRotation) return;

        if (matchPosition)
        {
            if (keepOffsetPos)
                transform.position = transformToMatch.position + posOffset;
            else
                transform.position = transformToMatch.position;
        }

        if (matchRotation)
        {
            if (keepOffsetPos)
                transform.rotation = Quaternion.Euler((transformToMatch.rotation.eulerAngles + rotOffset));
            else
                transform.rotation = transformToMatch.rotation;
        }
    }
}
