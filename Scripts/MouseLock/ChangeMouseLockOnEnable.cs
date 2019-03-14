public class ChangeMouseLockOnEnable : ChangeMouseLock_Base
{
    public bool mouseLocked = false;

    private void OnEnable()
    {
        ChangeCursorLock(mouseLocked);
    }
}
