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
    }

    public void SettingsBack()
    {
        settings.SetActive(false);
        title.SetActive(true);
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
