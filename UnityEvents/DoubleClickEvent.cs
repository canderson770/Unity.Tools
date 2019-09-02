using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DoubleClickEvent : MonoBehaviour, IPointerDownHandler
{
    [ReadOnly] public bool clicked = false;
    public float threshold = .5f;

    public UnityEvent OnDoubleClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(clicked)
        {
            OnDoubleClick.Invoke();
            clicked = false;
        }
        else
        {
            StartCoroutine(Click());
        }
    }

    private IEnumerator Click()
    {
        clicked = true;
        yield return new WaitForSeconds(threshold);
        clicked = false;
    }
}
