using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceRebuildLayout : MonoBehaviour
{
    public bool rebuildOnStart = true;

    private IEnumerator Start()
    {
        yield return null;

        if (rebuildOnStart)
            RebuildLists();
    }

    /// <summary>
    /// Force Rebuilds layout
    /// </summary>
    public void RebuildLists()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
    }
}
