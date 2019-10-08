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

    //  TODO optimize
    public void Update()
    {
        float leftOffset = Left;
        foreach (var item in left)
        {
            if (item != null && item.gameObject.activeSelf)
                leftOffset += item.rect.width;
        }

        float rightOffset = Right;
        foreach (var item in right)
        {
            if (item != null && item.gameObject.activeSelf)
                rightOffset += item.rect.width;
        }

        float topOffset = Top;
        foreach (var item in top)
        {
            if (item != null && item.gameObject.activeSelf)
                topOffset += item.rect.height;
        }

        float bottomOffset = Bottom;
        foreach (var item in bottom)
        {
            if (item != null && item.gameObject.activeSelf)
                bottomOffset += item.rect.height;
        }

        VerticalLayoutGroup vertical = transform.parent.GetComponent<VerticalLayoutGroup>();
        HorizontalLayoutGroup horizontal = transform.parent.GetComponent<HorizontalLayoutGroup>();
        layoutElement = GetComponent<LayoutElement>();

        if (vertical != null)
        {
            var vertRT = vertical.GetComponent<RectTransform>();
            if (vertRT != null)
            {
                var newHeight = vertRT.rect.height - topOffset - bottomOffset - GetLayoutGroupOffset(vertical);

                if (layoutElement != null)
                    layoutElement.minHeight = newHeight;

                rt.SetHeight(newHeight);
            }
        }
        else if (horizontal != null)
        {
            var horizRT = horizontal.GetComponent<RectTransform>();
            if (horizRT != null)
            {
                var newWidth = horizRT.rect.width - leftOffset - rightOffset - GetLayoutGroupOffset(horizontal);

                if (layoutElement != null)
                    layoutElement.minWidth = newWidth;

                rt.SetWidth(newWidth);
            }
        }
        else
        {
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.pivot = Vector2.one / 2;

            rt.SetLeft(leftOffset);
            rt.SetRight(rightOffset);
            rt.SetTop(topOffset);
            rt.SetBottom(bottomOffset);
        }
    }

    /// <summary>
    /// Calculates offset needed to counter layout group's padding and spacing
    /// </summary>
    private float GetLayoutGroupOffset(HorizontalOrVerticalLayoutGroup layoutGroup)
    {
        float offset = 0;

        if (layoutGroup != null)
        {
            if (layoutGroup is HorizontalLayoutGroup)
            {
                offset += layoutGroup.padding.left;
                offset += layoutGroup.padding.right;
            }
            else if (layoutGroup is VerticalLayoutGroup)
            {
                offset += layoutGroup.padding.top;
                offset += layoutGroup.padding.bottom;
            }

            offset += layoutGroup.spacing * top.Count;
            offset += layoutGroup.spacing * bottom.Count;
            offset += layoutGroup.spacing * left.Count;
            offset += layoutGroup.spacing * right.Count;
        }

        return offset;
    }
}
