using System.Collections;
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
        }
        else
        {
            waterTint.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            water = true;
            Debug.Log(water);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            water = false;
            Debug.Log(water);
        }
    }
}
