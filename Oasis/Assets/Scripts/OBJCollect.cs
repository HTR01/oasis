using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Collectable")
        {
            if (col.name == "Cube1")
            {
                Destroy(col.gameObject);
                Achievements.OBJCollected = true;
            }
        }
    }
}
