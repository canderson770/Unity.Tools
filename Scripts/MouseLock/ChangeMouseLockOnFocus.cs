public class ChangeMouseLockOnFocus : ChangeMouseLock_Base
{
    public bool lockOnFocus = true;

    private void OnApplicationFocus(bool focus)
    {
        if (lockOnFocus)
            ChangeCursorLock(focus);
    }
}
