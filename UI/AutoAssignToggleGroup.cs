using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoAssignToggleGroup : MonoBehaviour
{
    private Toggle[] toggles;
    private ToggleGroup toggleGroup;

    public bool overrideGroup = true;

    private IEnumerator Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();

        if (toggleGroup != null)
        {
            yield return null;
            toggles = GetComponentsInChildren<Toggle>();

            foreach (var toggle in toggles)
            {
                if (toggle != null)
                {
                    if (toggle.group == null || overrideGroup)
                    {
                        toggle.group = toggleGroup;
                    }
                }
            }
        }
    }
}
