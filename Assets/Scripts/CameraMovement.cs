using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private float CameraY;
    [SerializeField]
    private float MouseSens;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraY = Camera.main.transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getMouseInput(InputAction.CallbackContext context)
    {
        transform.Rotate(Vector3.up, context.ReadValue<Vector2>().x * MouseSens);
        CameraY -= context.ReadValue<Vector2>().y * MouseSens;
        CameraY = Mathf.Clamp(CameraY, -90, 90);
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(CameraY, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z));

        
    }
}
