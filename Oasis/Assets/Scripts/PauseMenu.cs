using GameAnalyticsSDK.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject achievements, settings, audioMenu, videoMenu;
    bool isPaused = false;
    bool audioOn = false;
    bool videoOn = false;
    bool settingsOn = false;
    bool achOn = false;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        /*if (Input.GetButtonDown("Cancel"))
        {
            if (settingsOn == true)
            {
                SettingsBack();
            }
            if (audioOn == true)
            {
                AudioBack();
            }
            if (videoOn == true)
            {
                videoBack();
            }
            if (achOn == true)
            {
                AchievementsBack();
            }
        }*/
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        achievements.SetActive(false);
        settings.SetActive(false);
        
    }

    public void Achivements()
    {
        achievements.SetActive(true);
        pause.SetActive(false);
        achOn = true;
    }
    
    public void Settings()
    {
        settings.SetActive(true);
        pause.SetActive(false);
        settingsOn = true;
    }

    public void SettingsBack()
    {
        settings.SetActive(false);
        pause.SetActive(true);
        settingsOn = false;
    }
    public void Audio()
    {
        audioMenu.SetActive(true);
        settings.SetActive(false);
        audioOn = true;
        settingsOn = false;
    }
    public void AudioBack()
    {
        settings.SetActive(true);
        audioMenu.SetActive(false);
        audioOn = false;
        settingsOn = true;
    }
    public void Video()
    {
        videoMenu.SetActive(true);
        settings.SetActive(false);
        videoOn = true;
        settingsOn = false;
    }
    public void videoBack()
    {
        settings.SetActive(true);
        videoMenu.SetActive(false);
        videoOn = false;
        settingsOn = true;
    }
    public void AchievementsBack()
    {
        achievements.SetActive(false);
        pause.SetActive(true);
        achOn = false;
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
