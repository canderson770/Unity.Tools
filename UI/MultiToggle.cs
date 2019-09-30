using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MultiToggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    public List<Image> images = new List<Image>();
    public Selectable.Transition transition = Selectable.Transition.ColorTint;
    public ColorBlock colors;

    [Space(20)]
    public int isOn = 0;

    [System.Serializable]
    public class ToggleEvent : UnityEvent<int>
    {
        public ToggleEvent() { }
    }
    public ToggleEvent onValueChanged;


    [ExecuteInEditMode]
    private void OnEnable()
    {
        SetToggle();
        onValueChanged.Invoke(isOn);
    }

    private void OnValidate()
    {
        if (images.Count > 0)
            isOn = Mathf.Clamp(isOn, 0, images.Count - 1);
        else
            isOn = 0;

        SetToggle();
    }

    /// <summary>
    /// Moves to next state in cycle
    /// </summary>
    private void Toggle()
    {
        if (images.Count > 0)
            isOn = (isOn + 1) % images.Count;
        else
            isOn = 0;

        onValueChanged.Invoke(isOn);
    }

    /// <summary>
    /// Changes UI to match isOn
    /// </summary>
    private void SetToggle()
    {
        //  Reset color
        foreach (var image in images)
        {
            SetColor(image, colors.normalColor);
        }

        //  if ColorTint, change color
        if (transition == Selectable.Transition.ColorTint)
        {
            if (images.Count > isOn && isOn >= 0)
            {
                SetColor(images[isOn], colors.selectedColor);
            }
        }
        // if sprite swap, enable only one image
        else if (transition == Selectable.Transition.SpriteSwap)
        {
            foreach (var image in images)
            {
                SetEnable(image, false);
            }

            if (images.Count > isOn && isOn >= 0)
            {
                SetEnable(images[isOn], true);
            }
        }
    }

    /// <summary>
    /// Change images' colors to highlight color
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var image in images)
        {
            SetColor(image, colors.highlightedColor);
        }
    }

    /// <summary>
    /// Change images' colors back to normal
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        SetToggle();
    }

    /// <summary>
    /// Change images' colors to pressed color
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (var image in images)
        {
            SetColor(image, colors.pressedColor);
        }
    }

    /// <summary>
    /// Change images' colors back to normal, toggles to next state
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
        SetToggle();
    }

    /// <summary>
    /// Changes the color of an image if not null
    /// </summary>
    private void SetColor(Image image, Color color)
    {
        if (image != null)
            image.color = color;
    }

    /// <summary>
    /// Enables/disables an image if not null
    /// </summary>
    private void SetEnable(Image image, bool enabled)
    {
        if (image != null)
            image.enabled = enabled;
    }
}
