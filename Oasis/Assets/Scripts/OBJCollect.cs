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
    public GameObject achievement1a, achievement2a, achievement3a, achievement4a, achievement5a, achievement6a, achievement7a, achievement8a, achievement9a;
    public Achievements ach;
    public GameObject panel, endScreen;
    int achNum = 0;

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
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement1");
                Destroy(col.gameObject);
                ach.Ach01();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement1" + ".jpg");
                achievement1.SetActive(true);
                achievement1a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement2")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement2");
                Destroy(col.gameObject);
                ach.Ach02();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement2" + ".jpg");
                achievement2.SetActive(true);
                achievement2a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement3")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement3");
                Destroy(col.gameObject);
                ach.Ach03();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement3" + ".jpg");
                achievement3.SetActive(true);
                achievement3a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement4")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement4");
                Destroy(col.gameObject);
                ach.Ach04();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement4" + ".jpg");
                achievement4.SetActive(true);
                achievement4a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement5")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement5");
                Destroy(col.gameObject);
                ach.Ach05();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement5" + ".jpg");
                achievement5.SetActive(true);
                achievement5a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement6")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement6");
                Destroy(col.gameObject);
                ach.Ach06();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement6" + ".jpg");
                achievement6.SetActive(true);
                achievement6a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement7")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement7");
                Destroy(col.gameObject);
                ach.Ach07();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement7" + ".jpg");
                achievement7.SetActive(true);
                achievement7a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement8")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement8");
                Destroy(col.gameObject);
                ach.Ach08();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement8" + ".jpg");
                achievement8.SetActive(true);
                achievement8a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            if (col.name == "Achievement9")
            {
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Achievement9");
                Destroy(col.gameObject);
                ach.Ach09();
                ScreenCapture.CaptureScreenshot(m_Path + "Achievement9" + ".jpg");
                achievement9.SetActive(true);
                achievement9a.SetActive(false);
                achNum++;
                if (achNum == 9)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "All Achievements Found");
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    endScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}