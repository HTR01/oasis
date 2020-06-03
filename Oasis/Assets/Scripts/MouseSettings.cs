using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSettings : MonoBehaviour
{
    public MouseLook mouseL;

    public void MouseChange(float mouseValue)
    {
        mouseL.mouseSensitivity = mouseValue;
    }
}
