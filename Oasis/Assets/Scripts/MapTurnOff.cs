using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTurnOff : MonoBehaviour
{
    public GameObject map;
    public bool mapIsOn = true;
    void Update()
    {
        if (Input.GetButtonDown("Screenshot"))
        {
            if (mapIsOn == true)
            {
                map.SetActive(false);
                mapIsOn = false;
            }        
        }else
        {
            map.SetActive(true);
            mapIsOn = true;
        }
    }
}
