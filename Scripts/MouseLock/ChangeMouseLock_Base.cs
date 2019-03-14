using UnityEngine;

public class ChangeMouseLock_Base : MonoBehaviour
{
    protected void ChangeCursorLock(bool isLocked)
    {
        Cursor.visible = !isLocked;

        if (isLocked)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
