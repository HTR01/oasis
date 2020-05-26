using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitch : MonoBehaviour
{
    public GameObject Moon;
    public GameObject Sun;

    void Update()
    {
        if(DayNightController.isDay == true)
        {
            Sun.SetActive(true);
            Moon.SetActive(false);
        }
        if (DayNightController.isDay == false)
        {
            Sun.SetActive(false);
            Moon.SetActive(true);
        }
        if (DayNightController.dayNeutral == true)
        {
            Sun.SetActive(true);
            Moon.SetActive(true);
        }
    }
}
