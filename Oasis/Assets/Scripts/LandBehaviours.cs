using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LandBehaviours : MonoBehaviour
{
    //basic requirements for movement
    float speed;
    Vector3 target;
    bool fedBool, grazeBool, idleBool, fleeBool;
    bool currentlyFleeing;

    //location distanceChecks
    float PlayerDistance;
    public float DistToFlee;
    float targetDist;

    //Objects
    public GameObject Player;
    GameObject Creature;
    NavMeshAgent agent;


    //graze Timer
    float grazeTime, grazeTimeStart;
    public float grazeMin, grazeMax;

    float enterGrazeTime;
    public float enterGrazeTimeStart;

    //idle Timer
    float idleExit, idleExitStart;
    public float idleExitMin, idleExitMax;

    float idleEnter, idleEnterStart;
    public float idleEnterMin, idleEnterMax;

    //
    float fleeTimer;
    public float fleeTimerStart;
    public float grazeRangeMin, grazeRangeMax;

    public GameObject targetMark;

    // Find randomPoint Grazing
    Vector3 RandomPoint(Vector3 center)
    {
        Vector3 result = center;
        for (int i = 0; i < 30;)
        {
            Vector2 TargetPoint = Random.insideUnitCircle * Random.Range(250, 500);
            Vector3 randomPoint = center + new Vector3(TargetPoint.x, 0, TargetPoint.y);

            return randomPoint;
        }


        return result;
    }


    Vector3 FleePoint(Vector3 center)
    {
        Vector3 result = center;
        for (int i = 0; i < 30;)
        {
            Vector2 TargetPoint = Random.insideUnitCircle * Random.Range(DistToFlee, 500);
            Vector3 randomPoint = center + new Vector3(TargetPoint.x, 0, TargetPoint.y);
            return randomPoint;

        }
        return result;
    }


    void Start()
    {
        idleEnterStart = Random.Range(idleEnterMin, idleEnterMax);
        idleExitStart = Random.Range(idleExitMin, idleExitMax);
        grazeTimeStart = Random.Range(grazeMin, grazeMax);


        idleEnter = idleEnterStart;
        idleExit = idleExitStart;
        grazeTime = grazeTimeStart;
        fleeTimer = fleeTimerStart;

        fedBool = false;
        grazeBool = true;
        idleBool = false;
        fleeBool = false;

        target = GameObject.Find("targetMarker").transform.position;
        Player = GameObject.Find("Player");
        Creature = this.gameObject;
        agent = Creature.GetComponent<NavMeshAgent>();

        agent.SetDestination(target);
    }

    // Update is called once per frame
    void Update()
    {

        print(enterGrazeTime + "Graze Timer");
        targetMark.transform.position = target;

        PlayerDistance = Vector3.Distance(Player.transform.position, Creature.transform.position);
        targetDist = Vector3.Distance(target, transform.position);




        //run method for different behaviour based on variable
        if (PlayerDistance < DistToFlee && fedBool == false)
        {
            fleeBool = true;
        }


        if (fleeBool == true)
        {
            grazeBool = false;
            idleBool = false;
            Flee();
            if (targetDist < 0.55)
            {
                enterGrazeTime -= Time.deltaTime;
                if (enterGrazeTime < 0)
                {
                    grazeBool = true;
                    fleeBool = false;
                    enterGrazeTime += enterGrazeTimeStart;
                }
            }
        }
        if (fedBool == true)
        {
            Follow();
        }
        if (grazeBool == true)
        {
            Graze();
        }
        if (idleBool == true)
        {
            Idle();
        }


        //Fleeing Behaviour
        void Flee()
        {
            if (currentlyFleeing == false)
            {
                if (target != FleePoint(transform.position))
                {
                    target = FleePoint(transform.position);
                    currentlyFleeing = true;
                }
            }
            if (currentlyFleeing == true && PlayerDistance > DistToFlee)
            {
                currentlyFleeing = false;
                fleeBool = false;
                grazeBool = true;
            }
            agent.SetDestination(target);
            FleeRecast();
        }

        //following player Behaviour
        void Follow()
        {
            if (targetDist <= 1)
            {
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }

            if (PlayerDistance >= 10)
            {
                grazeBool = true;
                fedBool = false;
            }
        }


        //Roaming terrain behaviour
        void Graze()
        {
            IdleEnterTimer();

            if (targetDist < 0.55f)
            {
                grazeTime -= Time.deltaTime;
            }

            if (grazeTime < 0)
            {
                if (target != RandomPoint(transform.position))
                {
                    target = RandomPoint(transform.position);
                }

                RandomRecast();


                agent.SetDestination(target);
                agent.isStopped = false;
                grazeTime += grazeTimeStart;

            }

            if (idleEnter < 0)
            {
                grazeBool = false;
                idleBool = true;
                idleEnter += idleEnterStart;
                grazeTime = grazeTimeStart;
            }
        }


        //sitting on spot behaviour
        void Idle()
        {
            agent.isStopped = true;
            runIdleTimer();
            if (idleExit < 0)
            {
                idleBool = false;
                grazeBool = true;
                agent.isStopped = false;
                idleExit += idleExitStart;
            }
        }




        //Run Timers
        void runIdleTimer()
        {
            idleExit -= Time.deltaTime;
        }
        void IdleEnterTimer()
        {
            idleEnter -= Time.deltaTime;
        }





        //Cast to find current postion/new position if on correct layer
        void RandomRecast()
        {
            Vector3 RayFrom = new Vector3(target.x, target.y + 1000, target.z);
            RaycastHit hit;

            if (Physics.Raycast(RayFrom, Vector3.down * 2000, out hit, Mathf.Infinity, layerMask: 1 << 8))
            {
                target = hit.point;

            }
            else
            {
                target = RandomPoint(transform.position);
                RandomRecast();
            }

        }


        void FleeRecast()
        {
            Vector3 RayFrom = new Vector3(target.x, target.y + 1000, target.z);
            RaycastHit hit;

            if (Physics.Raycast(RayFrom, Vector3.down * 2000, out hit, Mathf.Infinity, layerMask: 1 << 8))
            {
                target = hit.point;

            }
            else
            {
                target = FleePoint(transform.position);
                FleeRecast();
            }

        }
    }
}