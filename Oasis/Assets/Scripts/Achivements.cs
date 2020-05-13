using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achivements : MonoBehaviour
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


    // Update is called once per frame
    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");

        if(OBJCollected == true && ach01Code != 111)
        {
            StartCoroutine(TriggerAch01());
        }
    }

    //copy paste and edit me for additional achievements
    IEnumerator TriggerAch01()
    {
        achActive = true;
        ach01Code = 111;
        PlayerPrefs.SetInt("Ach0101", ach01Code);
        //achSound.Play();
        ach01Img.SetActive(true);
        achTitle.GetComponent<Text>().text = "Achievement Name";
        achDesc.GetComponent<Text>().text = "Achievement Description";
        achNote.SetActive(true);
        yield return new WaitForSeconds(5);
        //resetUI
        ach01Img.SetActive(false);
        achTitle.GetComponent<Text>().text = null;
        achDesc.GetComponent<Text>().text = null;
        achNote.SetActive(false);
        achActive = false;
    }
}
