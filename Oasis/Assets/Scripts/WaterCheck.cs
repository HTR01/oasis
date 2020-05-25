﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCheck : MonoBehaviour
{
    public bool water;
    public GameObject waterTint;

    void Update()
    {
        if(water == false)
        {
            waterTint.SetActive(false);
            RenderSettings.fog = false;
        }
        else
        {
            waterTint.SetActive(true);
            RenderSettings.fog = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            water = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            water = false;
        }
    }
}
