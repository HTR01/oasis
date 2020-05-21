using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakeScreenshot : MonoBehaviour
{
    string m_Path;

    private void Start()
    {
        m_Path = Application.dataPath + "/Screenshots/";

        if (!Directory.Exists(m_Path))
        {
            System.IO.Directory.CreateDirectory(m_Path);
        }
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Screenshot"))
        {
            Screenshot();
        }
    }

    void Screenshot()
    {
        string date = System.DateTime.Now.ToString();
        date = date.Replace("/", "-");
        date = date.Replace(" ", "_");
        date = date.Replace(":", "-");

        ScreenCapture.CaptureScreenshot(m_Path + "Screenshot" + date + ".jpg");
    }
}
