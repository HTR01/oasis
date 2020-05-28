using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AirBehaviours : MonoBehaviour
{
    //Location to move to
    Vector3 target;
    Vector3 dir;
    Vector3 oldDir;
    
    //Heightrange for flying
    public float heightMin, heightMax;


    //Distance measurements
    float targetDist;
    float playerDist;


    bool flyBool, idleBool, sleepBool, disturbed, targetBool;

    public float speed = 50;
    float fleeDist = 20;

    Rigidbody rb;
    GameObject Player;
    float t = 0;
    //Timers
    float idleEnterTime, flyEnterTime;

    //enter time
    public float flyEnterMax, idleEnterMax;


    Vector3 RandomPoint(Vector3 center)
    {
        Vector3 result = center;
        for (int i = 0; i < 30;)
        {
            Vector2 TargetPoint = Random.insideUnitCircle * Random.Range(250, 500);
            Vector3 randomPoint = center + new Vector3(TargetPoint.x, Random.Range(heightMin, heightMax), TargetPoint.y);

            return randomPoint;
        }


        return result;
    }


    private void Start()
    {
        Player = GameObject.Find("PlayerMaster");
        flyBool = true;
        target = RandomPoint(transform.position);
        RandomRecast();
        rb = GetComponent<Rigidbody>();
        flyEnterTime = flyEnterMax;
        idleEnterTime = idleEnterMax;
    }

    private void Update()
    {
        targetDist = Vector3.Distance(gameObject.transform.position, target);
        playerDist = Vector3.Distance(transform.position, Player.transform.position);
        if (DayNightController.isDay == false && disturbed == false)
        {
            sleepBool = true;
        }

        if (flyBool == true)
        {
            fly();
        }

        if (idleBool == true)
        {
            Idle();
        }

        if(sleepBool == true)
        {
            sleep();
        }
        if (disturbed == true)
        {
            nightFly();
        }
        if(targetBool == true)
        {
            RandomPoint(transform.position);
            RandomRecast();
            targetBool = false;
        }

    }



    void Idle()
    {
        GroundedRecast();
        Vector3 dir = (target - transform.position).normalized;
        rb.velocity = dir * speed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        if(targetDist <= 5)
        {
            flyEnterTime -= Time.deltaTime;
        }
        if (flyEnterTime < 0 || playerDist < fleeDist)
        {
            idleBool = false;
            flyBool = true;
            flyEnterTime = flyEnterMax;
            target = RandomPoint(transform.position);
            RandomRecast();
        }
    }

    void fly()
    {
        //Set direction, fly in direction at speed, rotate to face direction flying
        //if within range of target, find a new target
        dir = (target - transform.position).normalized;
        if (oldDir == null)
        {
            rb.velocity = dir * speed;
        }
        else
        {
            LerpTime();
            rb.velocity = Vector3.Lerp(oldDir, dir, t) * speed;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        if(targetDist < 1.5f)
        {
            t = 0;
            oldDir = dir;
            target = RandomPoint(transform.position);
            RandomRecast();
        }

        idleEnterTime -= Time.deltaTime;
        if (idleEnterTime < 0)
        {
            flyBool = false;
            idleBool = true;
            idleEnterTime += idleEnterMax;
        }

    }

    void sleep()
    {
        print("hit");
        GroundedRecast();
        Vector3 dir = (target - transform.position).normalized;
        rb.velocity = dir * speed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        if(playerDist <= fleeDist / 2)
        {
            print("canFlee");
            sleepBool = false;
            targetBool = true;
            disturbed = true;
        }
    }


    void nightFly()
    {
        dir = (target - transform.position).normalized;
        rb.velocity = dir * speed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        if (targetDist < 1.5f)
        {
            sleepBool = true;
            disturbed = false;
        }

    }


    void LerpTime()
    {
        t = Mathf.Clamp(t, 0, 1);
        if (t <= 1)
        {
            t += Time.deltaTime / 2;
        }
    }


    //Cast to find current postion/new position if on correct layer
    void RandomRecast()
    {
        Vector3 RayFrom = new Vector3(target.x, target.y + 1000, target.z);
        RaycastHit hit;

        if (Physics.Raycast(RayFrom, Vector3.down * 2000, out hit, Mathf.Infinity, layerMask: 1 << 8) || Physics.Raycast(RayFrom, Vector3.down * 2000, out hit, Mathf.Infinity, layerMask: 1 << 29))
        {
            
            //if ray hits correct layer, assign target to the point of hit, with a range for height
            target = new Vector3(hit.point.x, hit.point.y + Random.Range(heightMin, heightMax), hit.point.z);
        }
        else
        {
            //if ray fails, set a new target and cast the ray again
            target = RandomPoint(transform.position);
            RandomRecast();
        }

    }


    void GroundedRecast()
    {
        Vector3 RayFrom = new Vector3(target.x, target.y + 1000, target.z);
        RaycastHit hit;

        if (Physics.Raycast(RayFrom, Vector3.down * 2000, out hit, Mathf.Infinity, layerMask: 1 << 8))
        {

            //if ray hits correct layer, assign target to the point of hit
            target = new Vector3(hit.point.x, hit.point.y + 1.5f, hit.point.z);
        }
        else if(Physics.Raycast(RayFrom, Vector3.down * 2000, out hit, Mathf.Infinity, layerMask: 1 << 29))
        {
            //if ray fails, set a new target and cast the ray again
            target = RandomPoint(transform.position);
            GroundedRecast();
        }
        else
        {
            target = RandomPoint(transform.position);
            GroundedRecast();
        }
    }
}