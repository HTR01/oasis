using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject title;
    public GameObject settings;
    public GameObject audioMenu;
    public GameObject videoMenu;
    public GameObject controlsMenu;
    public GameObject titleEvent, contEvent, settEvent, audioEvent, videoEvent;
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        title.SetActive(false);
        settings.SetActive(true);
        titleEvent.SetActive(false); settEvent.SetActive(true);
    }

    public void SettingsBack()
    {
        settings.SetActive(false);
        title.SetActive(true);
        titleEvent.SetActive(true); settEvent.SetActive(false);
    }
    public void Audio()
    {
        audioMenu.SetActive(true);
        settings.SetActive(false);
        audioEvent.SetActive(true); settEvent.SetActive(false);
    }
    public void AudioBack()
    {
        settings.SetActive(true);
        audioMenu.SetActive(false);
        settEvent.SetActive(true); audioEvent.SetActive(false);
    }
    public void Controls()
    {
        controlsMenu.SetActive(true);
        settings.SetActive(false);
        settEvent.SetActive(false); contEvent.SetActive(true);
    }
    public void ControlsBack()
    {
        settings.SetActive(true);
        controlsMenu.SetActive(false);
        settEvent.SetActive(true); contEvent.SetActive(false);
    }
    public void Video()
    {
        videoMenu.SetActive(true);
        settings.SetActive(false);
        videoEvent.SetActive(true); settEvent.SetActive(false);
    }
    public void videoBack()
    {
        settings.SetActive(true);
        videoMenu.SetActive(false);
        settEvent.SetActive(true); videoEvent.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
