using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public bool isCursorLocked { get; private set; } = false;

    private void Start()
    {
        ToggleLockCursor();
    }

    public void ToggleLockCursor()
    {
        if (!isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        isCursorLocked = !isCursorLocked;
    }
}
