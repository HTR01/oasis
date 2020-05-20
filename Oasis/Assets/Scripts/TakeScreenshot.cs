using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;
using UnityEditor;
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
        string date = System.DateTime.Now.ToString();
        date = date.Replace("/", "-");
        date = date.Replace(" ", "_");
        date = date.Replace(":", "-");

        if (Input.GetButtonDown("Screenshot"))
        {
            ScreenCapture.CaptureScreenshot(m_Path + "Screenshot" + date + ".jpg");
        }
    }
}
