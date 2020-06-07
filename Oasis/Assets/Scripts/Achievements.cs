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
    public GameObject ach01Img, ach02Img, ach03Img, ach04Img, ach05Img, ach06Img, ach07Img, ach08Img, ach09Img;
    public static bool OBJCollected;
    //public int ach01Code, ach02Code;

    float timer = 5;
    float timerStart = 5;

    private void Start()
    {
        //PlayerPrefs.SetInt("Ach01", 111);
        //PlayerPrefs.SetInt("Ach02", 112);
        //OBJCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ach01Code = PlayerPrefs.GetInt("Ach01");
        //ach02Code = PlayerPrefs.GetInt("Ach02");

        /*if (OBJCollected == true && ach01Code == 111)
        {
            Ach01();
        }
        if (OBJCollected == true && ach02Code == 112)
        {
            Ach02();
        }*/
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
    
    public void Ach01()
    {
        achActive = true;
        //ach01Code = 0;
        //PlayerPrefs.SetInt("Ach01", ach01Code);
        //achSound.Play();
        ach01Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Boot";
        achDesc.GetComponent<Text>().text = "Why a boot...";
        achNote.SetActive(true);
        //OBJCollected = false;
        //ResetUI();
    }

    public void Ach02()
    {
        achActive = true;
        //ach02Code = 0;
        //PlayerPrefs.SetInt("Ach02", ach02Code);
        //achSound.Play();
        ach02Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Bison";
        achDesc.GetComponent<Text>().text = "You found a bison!";
        achNote.SetActive(true);
        //OBJCollected = false;
        //ResetUI();
    }

    public void Ach03()
    {
        achActive = true;
        ach03Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Butterfly";
        achDesc.GetComponent<Text>().text = "Wait no, don't fly away! ...Come back.";
        achNote.SetActive(true);
    }
    public void Ach04()
    {
        achActive = true;
        ach04Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Chalice";
        achDesc.GetComponent<Text>().text = "It's a golden cup.";
        achNote.SetActive(true);
    }
    public void Ach05()
    {
        achActive = true;
        ach05Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Crane";
        achDesc.GetComponent<Text>().text = "I hope I don't have to find 999 more...";
        achNote.SetActive(true);
    }
    public void Ach06()
    {
        achActive = true;
        ach06Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Crown";
        achDesc.GetComponent<Text>().text = "You're the Ruler of the World!";
        achNote.SetActive(true);
    }
    public void Ach07()
    {
        achActive = true;
        ach07Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Fish";
        achDesc.GetComponent<Text>().text = "No you can't eat it. Stop pressing E.";
        achNote.SetActive(true);
    }
    public void Ach08()
    {
        achActive = true;
        ach08Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Broken Spear";
        achDesc.GetComponent<Text>().text = "Ok... But why was it there?";
        achNote.SetActive(true);
    }
    public void Ach09()
    {
        achActive = true;
        ach09Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Turtle";
        achDesc.GetComponent<Text>().text = "Turtle!";
        achNote.SetActive(true);
    }

    void ResetUI()
    {
        achActive = false;
        ach01Img.SetActive(false); ach02Img.SetActive(false); ach03Img.SetActive(false); ach04Img.SetActive(false); ach05Img.SetActive(false);
        ach06Img.SetActive(false); ach07Img.SetActive(false); ach08Img.SetActive(false); ach09Img.SetActive(false);
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = null;
        achDesc.GetComponent<Text>().text = null;
        timer = timerStart;
    }
}
