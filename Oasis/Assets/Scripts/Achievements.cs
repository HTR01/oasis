using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{

    //Universal Variables
    public GameObject achNote;
    //public AudioSource achSound;
    public bool achActive;
    public GameObject achTitle, achDesc;

    //Achievement01
    public GameObject ach01Img;
    public static bool OBJCollected;
    public int ach01Code;

    float timer = 5;
    float timerStart = 5;


    private void Start()
    {
        PlayerPrefs.SetInt("Ach01", 0);
        OBJCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");

        if (OBJCollected == true && ach01Code != 111)
        {
            Ach01();
        }
        if (timer <= 0)
        {
            ResetUI();
        }

    }

    private void FixedUpdate()
    {
        if (achActive == true)
        {
            timer -= Time.deltaTime;
        }
    }

    //copy paste and edit me for additional achievements
    



    void Ach01()
    {
        achActive = true;
        ach01Code = 111;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        //achSound.Play();
        ach01Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Achievement Name";
        achDesc.GetComponent<Text>().text = "Achievement Description";
        achNote.SetActive(true);
        //resetUI
    }

    void ResetUI()
    {
        achActive = false;
        ach01Img.SetActive(false);
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = null;
        achDesc.GetComponent<Text>().text = null;
        timer = timerStart;
        print("hit");
    }
}
