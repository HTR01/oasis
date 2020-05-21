using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    bool cameraFP = true;
    public Camera FPCamera;
    public Camera TPCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (cameraFP == true)
            {
                cameraFP = false;
                FPCamera.enabled = false;
                TPCamera.enabled = true;
            }
            else
            {
                cameraFP = true;
                FPCamera.enabled = true;
                TPCamera.enabled = false;
            }
        }
    }
}
