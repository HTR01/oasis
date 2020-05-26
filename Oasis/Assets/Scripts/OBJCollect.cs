using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using System.IO;

public class OBJCollect : MonoBehaviour
{
    string m_Path;

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
            if (col.name == "Cube1")
            {
                GameAnalytics.NewDesignEvent("Achievement", 1);
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Tutorial");
                Destroy(col.gameObject);
                Achievements.OBJCollected = true;
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement1" + ".jpg");
            }
        }
    }
}