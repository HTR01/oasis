using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject panel, endScreen;
    public void Back()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        endScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
