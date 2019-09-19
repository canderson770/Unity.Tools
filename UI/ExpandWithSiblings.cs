using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ExpandWithSiblings : MonoBehaviour
{
    public List<RectTransform> left = new List<RectTransform>();
    public List<RectTransform> right = new List<RectTransform>();
    public List<RectTransform> top = new List<RectTransform>();
    public List<RectTransform> bottom = new List<RectTransform>();
    private RectTransform rt;
    private LayoutElement layoutElement;

    public float Left, Right, Bottom, Top;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        layoutElement = GetComponent<LayoutElement>();
    }

    public void Update()
    {
        float leftOffset = Left;
        foreach (var item in left)
        {
            if (item.gameObject.activeSelf)
                leftOffset += item.rect.width;
        }

        float rightOffset = Right;
        foreach (var item in right)
        {
            if (item.gameObject.activeSelf)
                rightOffset += item.rect.width;
        }

        float topOffset = Top;
        foreach (var item in top)
        {
            if (item.gameObject.activeSelf)
                topOffset += item.rect.height;
        }

        float bottomOffset = Bottom;
        foreach (var item in bottom)
        {
            if (item.gameObject.activeSelf)
                bottomOffset += item.rect.height;
        }

        VerticalLayoutGroup vertical = transform.parent.GetComponent<VerticalLayoutGroup>();
        HorizontalLayoutGroup horizontal = transform.parent.GetComponent<HorizontalLayoutGroup>();
        layoutElement = GetComponent<LayoutElement>();

        if (vertical != null)
        {
            RectTools.SetHeight(rt, horizontal.GetComponent<RectTransform>().rect.height - topOffset - bottomOffset);
        }
        else if (horizontal != null)
        {
            if (layoutElement != null)
                layoutElement.minWidth = horizontal.GetComponent<RectTransform>().rect.width - leftOffset - rightOffset;

            RectTools.SetWidth(rt, horizontal.GetComponent<RectTransform>().rect.width - leftOffset - rightOffset);
        }
        else
        {
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.pivot = Vector2.one / 2;

            RectTools.SetLeft(rt, leftOffset);
            RectTools.SetRight(rt, rightOffset);
            RectTools.SetTop(rt, topOffset);
            RectTools.SetBottom(rt, bottomOffset);
        }
    }
}
