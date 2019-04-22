using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBoolEvents : MonoBehaviour
{
    public Animator anim;

    /// <summary>
    /// Toggles bool value of boolName
    /// </summary>
    public void EVENT_ToggleBool(string boolName)
    {
        if (anim == null) return;
        anim.SetBool(boolName, !anim.GetBool(boolName));
    }

    /// <summary>
    /// Sets bool false for boolName
    /// </summary>
    public void EVENT_SetBoolFalse(string boolName)
    {
        if (anim == null) return;
        anim.SetBool(boolName, false);
    }

    /// <summary>
    /// Sets bool true for boolName
    /// </summary>
    public void EVENT_SetBoolTrue(string boolName)
    {
        if (anim == null) return;
        anim.SetBool(boolName, true);
    }
}
