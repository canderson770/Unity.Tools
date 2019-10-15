using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPointerExit_UnityEvent : MonoBehaviour, IPointerExitHandler
{
    public UnityEvent onPointerExit;

    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExit.Invoke();
    }
}
