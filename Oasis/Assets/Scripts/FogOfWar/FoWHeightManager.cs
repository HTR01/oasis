using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoWHeightManager : MonoBehaviour
{

    GameObject Player;
    GameObject canvas;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerMaster");
        canvas = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.position = new Vector3(80.4f, Player.transform.position.y + y, -57.2f);
    }
}
