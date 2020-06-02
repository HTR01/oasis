using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;

    Camera cam;

    float distance = 20.0f;
    float currentX = 0.0f;
    float currentY = 0.0f;
    public float mouseSensitivity = 3f;
    //float controllerX = 0.0f;
    //float controllerY = 0.0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //controllerX += Input.GetAxis("Controller X");
        //controllerY += Input.GetAxis("Controller Y");


        lookAt.Rotate(Vector3.up * mouseX);
        currentY = Mathf.Clamp(currentY, 0f, 50f);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        //Quaternion rotationCon = Quaternion.Euler(controllerY, controllerX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        //camTransform.position = lookAt.position + rotationCon * dir;
        camTransform.LookAt(lookAt.position);
    }
}
