using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    int random;
    

    void Update()
    {
        if (Input.GetButtonDown("Screenshot"))
        {
            ScreenCapture.CaptureScreenshot("Screenshot" + Time.time + ".jpg");
        }
    }
}
