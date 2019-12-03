using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchScreenSize : MonoBehaviour
{
    private RectTransform rt;

    private void Awake()
    {
        rt = (RectTransform)transform;
    }

    private void OnEnable()
    {
        StartCoroutine(MatchCanvas());
    }

    private IEnumerator MatchCanvas()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform.parent);
        yield return null;
        RectTransform canvas = (RectTransform)transform.root;
        rt.SetPivot(canvas.pivot);
        rt.position = canvas.position;
        rt.SetWidth(canvas.sizeDelta.x);
        rt.SetHeight(canvas.sizeDelta.y);
    }
}
