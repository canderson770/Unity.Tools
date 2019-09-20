using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Overrides the Toggle to change the functionality of the Selected Color
/// </summary>
public class BetterToggle : Toggle
{
    private Color normalColor = Color.clear;
    private Sprite normalSprite;

    protected override void Awake()
    {
        normalColor = colors.normalColor;
        if (targetGraphic != null && targetGraphic is Image)
            normalSprite = ((Image)targetGraphic).sprite;

        var nav = navigation;
        nav.mode = Navigation.Mode.None;
        navigation = nav;

        onValueChanged.AddListener(ValueToggled);
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        ValueToggled();
    }

    public void ValueToggled(bool value = false)
    {
        if (Application.isPlaying)
        {
            if (transition == Transition.ColorTint)
            {
                if (isOn)
                    SetColor(colors.selectedColor);
                else
                    SetColor(normalColor);
            }
            else if (transition == Transition.SpriteSwap && targetGraphic != null && targetGraphic is Image)
            {
                if (isOn)
                    ((Image)targetGraphic).sprite = spriteState.selectedSprite;
                else
                    ((Image)targetGraphic).sprite = normalSprite;
            }
        }
    }

    private void SetColor(Color color)
    {
        var newColors = colors;
        newColors.normalColor = color;
        colors = newColors;
    }
}
