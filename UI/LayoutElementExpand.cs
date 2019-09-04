using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutElementExpand : MonoBehaviour
{
    public enum Direction { Vertical, Horizontal };
    public Direction direction = Direction.Horizontal;

    private RectTransform root;
    private RectTransform rectTransform;
    private List<RectTransform> siblings = new List<RectTransform>();
    private float currentSize;


    private void Start()
    {
        root = transform.parent.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if (root == null || rectTransform == null) return;

        float size = CalculateSize();
        if (currentSize != size)
        {
            if (direction == Direction.Horizontal)
                rectTransform.sizeDelta = new Vector2(size, rectTransform.sizeDelta.y);
            else
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, size);

            currentSize = size;
        }
    }

    private float CalculateSize()
    {
        siblings.Clear();
        foreach (Transform child in transform.parent)
        {
            if (child != transform)
            {
                if (child.gameObject.activeInHierarchy == false) continue;

                LayoutElement element = child.GetComponent<LayoutElement>();
                if (element != null && element.ignoreLayout) continue;

                RectTransform r = child.GetComponent<RectTransform>();
                if (r != null) siblings.Add(r);
            }
        }

        float taken = 0;

        if (direction == Direction.Horizontal)
        {
            foreach (var sibling in siblings)
                taken += sibling.sizeDelta.x;

            return root.sizeDelta.x - taken;
        }
        else
        {
            foreach (var sibling in siblings)
                taken += sibling.sizeDelta.y;

            return root.sizeDelta.y - taken;
        }
    }
}
