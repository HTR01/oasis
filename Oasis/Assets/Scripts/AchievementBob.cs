using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementBob : MonoBehaviour
{

    bool Switch = false;
    float t = 0;
    Vector3 LerpMax, LerpMin;
    // Start is called before the first frame update
    void Start()
    {
        LerpMin = transform.position;
        LerpMax = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        transform.position = Vector3.Lerp(LerpMin, LerpMax, t);
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }



    void Timer()
    {
        if (Switch == false)
        {
            t += 0.5f * Time.deltaTime;
        }
        else
        {
            t -= 0.5f * Time.deltaTime;
        }

        if (t > 1 || t < 0)
        {
            Switch = !Switch;
        }
    }
}
