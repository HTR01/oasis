using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioSource land;
    public AudioSource underwater;
    public AudioSource waterAmbience;
    public AudioSource landAmbience;
    bool isLandPlaying = true;
    bool isWaterPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.water == true && (isLandPlaying == true && isWaterPlaying == false))
        {
            underwater.Play();
            waterAmbience.Play();
            land.Stop();
            landAmbience.Stop();
            isLandPlaying = false;
            isWaterPlaying = true;
        }
        if (PlayerMovement.water == false && (isLandPlaying == false && isWaterPlaying == true))
        {
            underwater.Stop();
            waterAmbience.Stop();
            land.Play();
            landAmbience.Play();
            isLandPlaying = true;
            isWaterPlaying = false;
        }

    }
}
