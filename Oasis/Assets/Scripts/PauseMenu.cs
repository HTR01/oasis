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
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == true)
            {
                Resume();
            }
        }
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
    }
    
    public void Settings()
    {
        settings.SetActive(true);
        pause.SetActive(false);
    }

    public void SettingsBack()
    {
        settings.SetActive(false);
        pause.SetActive(true);
    }
    public void Audio()
    {
        audioMenu.SetActive(true);
        settings.SetActive(false);
    }
    public void AudioBack()
    {
        settings.SetActive(true);
        audioMenu.SetActive(false);
    }
    public void Video()
    {
        videoMenu.SetActive(true);
        settings.SetActive(false);
    }
    public void videoBack()
    {
        settings.SetActive(true);
        videoMenu.SetActive(false);
    }
    public void AchievementsBack()
    {
        achievements.SetActive(false);
        pause.SetActive(true);
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
