using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class OBJCollect : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Collectable")
        {
            if (col.name == "Cube1")
            {
                
                GameAnalytics.NewDesignEvent("Achievement", 1);
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Tutorial");
                Destroy(col.gameObject);
                Achievements.OBJCollected = true;
            }
        }
    }
}
