using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class OnVideoEndUnityEvent : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public UnityEvent onVideoEnd;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void OnEnable()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached += VideoEnd;
    }
    private void OnDisable()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= VideoEnd;
    }

    private void VideoEnd(VideoPlayer vp)
    {
        onVideoEnd.Invoke();
    }
}
