﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaterBehaviours : MonoBehaviour
{
    public static GameObject[] _waypoints;
    Transform[] _waypointTransform;
    [SerializeField] GameObject player;
    Transform targetWaypoint;
    int index;
    float dist, playerDist;
    [SerializeField] float fleeDist = 10;

    GameObject attachedObj;
    Rigidbody rb;

    bool fleeBool, currentlyFleeing;
    //detecting furthest point from player
    float farDist;
    float curDist;
    GameObject fleeTo;
    Vector3 target;
    GameObject furthestObj;

    public Dictionary<float, GameObject> waypointToDist = new Dictionary<float, GameObject>();
    public List<GameObject> waypointList;

    //Movement
    //Directions
    Vector3 dir, oldDir, targetSite;
    float t = 0;

    //Speed
    public float speed;



    //GameObject furthestObj;
    GameObject getFurthestGO(List<GameObject> OBJSConsidered)
    {
        Debug.Log(OBJSConsidered.Count);
        float furthestDist = 0;

        foreach (var obj in OBJSConsidered)
        {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            if (dist > furthestDist)
            {
                furthestDist = dist;
                furthestObj = obj;
                //print(obj.name);
            }
        }
        //print(furthestObj.name + "farOBJ");
        return furthestObj;
    }


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

    Transform waypointPos(GameObject[] _selection)
    {
        index = Random.Range(0, _waypoints.Length - 1);
        Transform pos = _waypoints[index].transform;
        return pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        attachedObj = this.gameObject;
        rb = attachedObj.GetComponent<Rigidbody>();
        fleeBool = false;
        _waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        targetSite = RandomPointOnTarget(transform.position);
        player = GameObject.Find("PlayerMaster");
        oldDir = Vector3.zero;
    }

    IEnumerator PopList()
    {
        yield return new WaitForSeconds(0.1f);
        waypointList.AddRange(_waypoints);
        StopCoroutine("PopList");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(furthestObj.name);

        if (waypointList.Count == 0)
        {
            StartCoroutine("PopList");
        }

        //movement
        dir = (target - transform.position).normalized;
        if (oldDir == Vector3.zero)
        {
            print(rb);
            rb.velocity = dir * speed;
        }
        else
        {
            LerpTime();
            rb.velocity = Vector3.Lerp(oldDir, dir, t) * speed;
            print(oldDir);
        }

        //check if fleeing or not
        if (fleeBool == false)
        {
            Patrol();
        }
        else
        {
            Flee();
        }

        //if the player is within range, set to fleeing
        if (playerDist < fleeDist)
        {
            fleeBool = true;
        }


        void Patrol()
        {
            if(target == null)
            {
                target = waypointPos(_waypoints).position;
            }
            //if object is within range, choose a new location to move to at random
            if (dist < 0.5f)
            {
                target = waypointPos(_waypoints).position;
                oldDir = dir;
            }
        }

        void Flee()
        {
            if (currentlyFleeing == false)
            {
                if (target != getFurthestGO(waypointList).transform.position)
                {
                    checkForFurthest();
                    currentlyFleeing = true;
                }
            }
        }



        void checkForFurthest()
        {
            target = getFurthestGO(waypointList).transform.position;
        }




        //print(furthestObj);

        //  getFurthestGO(waypointList);
        //RandomPointOnTarget(transform.position);
        //target.position = furthestObj.transform.position;
        //print(target.position);


    }

    void LerpTime()
    {
        t = Mathf.Clamp(t, 0, 1);
        if (t <= 1)
        {
            t += Time.deltaTime / 2;
        }
    }

}


