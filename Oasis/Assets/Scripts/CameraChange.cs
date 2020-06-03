using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    bool cameraFP = true;
    //public Camera FPCamera;
    //public Camera TPCamera;
    public GameObject FPCamera;
    public GameObject TPCamera;

    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (cameraFP == true)
            {
                cameraFP = false;
                FPCamera.SetActive(false);
                TPCamera.SetActive(true);
                //FPCamera.enabled = false;
                //TPCamera.enabled = true;
            }
            else
            {
                cameraFP = true;
                FPCamera.SetActive(true);
                TPCamera.SetActive(false);
                //FPCamera.enabled = true;
                //TPCamera.enabled = false;
            }
        }

        if(PlayerMovement.water == true)
        {
            cameraFP = true;
            FPCamera.SetActive(true);
            TPCamera.SetActive(false);
        }
    }
}
