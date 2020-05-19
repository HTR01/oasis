using GameAnalyticsSDK.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    public Vector3 Ahead, Side;

    public float negative;
    public float positive;

    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
     }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        float controllerX = Input.GetAxisRaw("Controller X") * mouseSensitivity * Time.deltaTime;
        float controllerY = Input.GetAxisRaw("Controller Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation -= controllerY;
        xRotation = Mathf.Clamp(xRotation, negative, positive);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.up * controllerX);

        Ahead = this.gameObject.transform.forward;
        Side = this.gameObject.transform.right;
    }
}
