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
    public GameObject achievement2, achievement3, achievement4, achievement5, achievement6, achievement7, achievement8, achievement9;
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
            if (col.name == "Achievement3")
            {
                GameAnalytics.NewDesignEvent("Achievement", 3);
                Destroy(col.gameObject);
                ach.Ach03();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement3" + ".jpg");
                achievement3.SetActive(true);
            }
            if (col.name == "Achievement4")
            {
                GameAnalytics.NewDesignEvent("Achievement", 4);
                Destroy(col.gameObject);
                ach.Ach04();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement4" + ".jpg");
                achievement4.SetActive(true);
            }
            if (col.name == "Achievement5")
            {
                GameAnalytics.NewDesignEvent("Achievement", 5);
                Destroy(col.gameObject);
                ach.Ach05();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement5" + ".jpg");
                achievement5.SetActive(true);
            }
            if (col.name == "Achievement6")
            {
                GameAnalytics.NewDesignEvent("Achievement", 6);
                Destroy(col.gameObject);
                ach.Ach06();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement6" + ".jpg");
                achievement6.SetActive(true);
            }
            if (col.name == "Achievement7")
            {
                GameAnalytics.NewDesignEvent("Achievement", 7);
                Destroy(col.gameObject);
                ach.Ach07();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement7" + ".jpg");
                achievement7.SetActive(true);
            }
            if (col.name == "Achievement8")
            {
                GameAnalytics.NewDesignEvent("Achievement", 8);
                Destroy(col.gameObject);
                ach.Ach08();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement8" + ".jpg");
                achievement8.SetActive(true);
            }
            if (col.name == "Achievement9")
            {
                GameAnalytics.NewDesignEvent("Achievement", 9);
                Destroy(col.gameObject);
                ach.Ach09();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement9" + ".jpg");
                achievement9.SetActive(true);
            }
        }
    }
}