using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviours : MonoBehaviour
{
    public GameObject[] Waypoints;
    GameObject player;
    Transform targetWaypoint;
    int index;
    float dist, playerDist;
    public float fleeDist = 10;
    
    Rigidbody rb;

    bool fleeBool;
    //detecting furthest point from player
    float farDist;
    float curDist;
    GameObject fleeTo;



    List<GameObject> waypointList = new List<GameObject>();
    List<float> distances = new List<float>();



    //Movement
        //Directions
    Vector3 dir, oldDir, targetSite;
        //Speed
    public float speed;

    Vector3 RandomPointOnTarget(Vector3 center)
    {
        Vector3 result = center;
        for (int i = 0; i < 1;)
        {
            Vector3 TargetPoint = Random.insideUnitSphere * Random.Range(-5, 5);
            Vector3 RandomPointOnTarget = targetWaypoint.position + TargetPoint;
            return RandomPointOnTarget;
        }
        return result;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        index = Random.Range(0, (Waypoints.Length - 1));
        GameObject.FindGameObjectsWithTag("Waypoints");
        targetSite = RandomPointOnTarget(transform.position);
        player = GameObject.Find("PlayerMaster");

        foreach (GameObject obj in Waypoints)
        {
            waypointList.Add(obj);
        }

        foreach (GameObject site in waypointList)
        {
            float distance = Vector3.Distance(transform.position, site.transform.position);
            distances.Add(distance);
        }


        Dictionary<GameObject, float> waypointToDist = new Dictionary<GameObject, float>();
        foreach (GameObject obj in waypointList)
        {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            waypointToDist.Add(obj, dist);
        }

        List<waypointList>.get(waypointList[0]);
    }

    // Update is called once per frame
    void Update()
    {

        print(curDist + "near");
        print(farDist + "far");

        if (dist < 3)
        {
            fleeBool = true;
            print(fleeBool);
            flee();
        }
        else
        {
            fleeBool = false;
        }

        //    targetWaypoint = Waypoints[index].transform;

        dist = Vector3.Distance(transform.position, fleeTo.transform.position);
        //    playerDist = Vector3.Distance(transform.position, player.transform.position);


        //    if (playerDist < fleeDist)
        //    {
        //        flee();
        //    }
        //    else
        //    {
        //        patrol();
        //    }
        //    rb.velocity = dir * speed;


        //}



        //void patrol()
        //{

        //}

        void flee()
        {
            foreach (GameObject site in Waypoints)
            {
                curDist = Vector3.Distance(transform.position, site.transform.position);

                if (curDist > farDist)
                {
                    farDist = curDist;
                    fleeTo = site;
                }

                //print(Vector3.Distance(transform.position, site.transform.position) + site.name);
                //print(fleeTo.name);





            }
        }
    }
}


