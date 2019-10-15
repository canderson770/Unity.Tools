using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Delay_UnityEvent : MonoBehaviour
{
    public float delayTime = 1;
    public bool runOnStart = false;
    public UnityEvent afterDelay;

    private void Start()
    {
        if (runOnStart)
            StartDelay();
    }

    public void StartDelay()
    {
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        afterDelay.Invoke();
    }
}
