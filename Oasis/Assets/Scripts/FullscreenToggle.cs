using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public bool fullscreen = true;
    public Toggle fullscreenCheck;

    void Update()
    {
        if (fullscreenCheck.isOn == true)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
}
