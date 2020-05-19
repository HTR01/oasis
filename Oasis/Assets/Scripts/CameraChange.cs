using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    bool cameraFP = true;
    public GameObject FPCamera;
    public GameObject TPCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (cameraFP == true)
            {
                FPCamera.SetActive(false);
                TPCamera.SetActive(true);
                cameraFP = false;
            }
            else
            {
                FPCamera.SetActive(true);
                TPCamera.SetActive(false);
                cameraFP = true;
            }
        }
    }
}
