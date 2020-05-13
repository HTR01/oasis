using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public GameObject dayNight;
    public float rotateSpeed = 1f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dayNight.transform.rotation = Quaternion.Euler(1f, 0f, 0f);
        dayNight.transform.Rotate(rotateSpeed * Time.time, 0f, 0f);

        Debug.Log(Time.time);
    }
}
