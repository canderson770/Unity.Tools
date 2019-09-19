using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsHovered : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isHovering;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
