using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using System.IO;
using UnityEngine.UI;

public class OBJCollect : MonoBehaviour
{
    string m_Path;
    public GameObject achievement1;
    public GameObject achievement2;
    public Achievements ach;

    void Start()
    {
        m_Path = Application.dataPath + "/Screenshots/Achievements/";

        if (!Directory.Exists(m_Path))
        {
            System.IO.Directory.CreateDirectory(m_Path);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Collectable")
        {
            if (col.name == "Achievement1")
            {
                GameAnalytics.NewDesignEvent("Achievement", 1);
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Tutorial");
                Destroy(col.gameObject);
                ach.Ach01();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement1" + ".jpg");
                achievement1.SetActive(true);
            }
            if (col.name == "Achievement2")
            {
                GameAnalytics.NewDesignEvent("Achievement", 2);
                Destroy(col.gameObject);
                ach.Ach02();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement2" + ".jpg");
                achievement2.SetActive(true);
            }
        }
    }
}