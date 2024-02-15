using UnityEngine;

public class Mouse : MonoBehaviour
{
    private void Start()
    {
        // Unlock the cursor when the script starts
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        // Unlock the cursor when a certain condition is met
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
