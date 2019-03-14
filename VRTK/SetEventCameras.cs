using UnityEngine;

/// <summary>
/// Sets Event Cameras on all canvases on scene
/// <para>(For optimization of UI, you do NOT want to leave event cameras unassigned)</para>
/// </summary>
public class SetEventCameras : MonoBehaviour
{
    private Canvas[] canvases;
    private Camera mainCamera;

    private void Start()
    {
        //  if camera was not set, find camera on rig
        if (mainCamera == null)
            mainCamera = transform.root.GetComponentInChildren<Camera>();

        //  if no camera found use main Camera
        if (mainCamera == null)
            mainCamera = Camera.main;

        //  if still null, give up
        if (mainCamera == null) return;

        //  loop through cameras and set the event camera if null
        canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            if (canvas.worldCamera == null)
                canvas.worldCamera = mainCamera;
        }
    }
}
