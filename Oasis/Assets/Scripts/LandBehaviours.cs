using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LandBehaviours : MonoBehaviour
{
    //basic requirements for movement
    float speed;
    Transform target;
    bool fedBool, grazeBool, idleBool, fleeBool;
    
    //location distanceChecks
    float PlayerDistance;
    public float DistToFlee;
    float targetDist;
    public GameObject RayHit;

    //Objects
    GameObject Player;
    GameObject Creature;
    NavMeshAgent agent;

    //Timers
    public float grazeTimeStart, idleTimeStart, ReturnGrazeStart;

    float returnGrazeTime, grazeTime, idleTime;
    // Start is called before the first frame update

    
        // Find randomPoint Grazing
    Vector3 RandomPoint(Vector3 center)
    {
        Vector3 result = center;
        for (int i = 0; i < 30; i++)
        {

            Vector2 TargetPoint = Random.insideUnitCircle * Random.Range(250, 500);
            Vector3 randomPoint = center + new Vector3(TargetPoint.x, 0, TargetPoint.y);
            
            Debug.Log(randomPoint + "SpotCoords");

            RaycastHit hit;
            if (Physics.Raycast(new Vector3(target.transform.position.x, target.transform.position.y + 1000, target.transform.position.z), Vector3.down, out hit, Mathf.Infinity, layerMask: 1<<11))
            {
                Debug.Log(hit.point + "hit coords");
                Debug.Log(hit.collider.name);
            }
            return randomPoint;
        }


        return result;
    }


    Vector3 FleePoint(Vector3 center)
    {
        Vector3 result = center;
        for (int i = 0; i < 30; i++)
        {
            Vector2 TargetPoint = Random.insideUnitCircle * Random.Range(DistToFlee, 500);
            Vector3 randomPoint = center + new Vector3(TargetPoint.x, 0, TargetPoint.y);
            return randomPoint;

        }
        return result;
    }




    void Start()
    {
        fedBool = false;
        grazeBool = true;
        idleBool = false;

        target = GameObject.Find("targetMarker").transform;
        Player = GameObject.Find("Player");
        Creature = this.gameObject;
        agent = Creature.GetComponent<NavMeshAgent>();

        agent.SetDestination(target.position);
        grazeTime = grazeTimeStart;
        idleTime = idleTimeStart;
        returnGrazeTime = ReturnGrazeStart;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerDistance = Vector3.Distance(Player.transform.position, Creature.transform.position);
        targetDist = Vector3.Distance(target.transform.position, transform.position);

        if (fleeBool == true)
        {
            if (targetDist < 0.5)
            {
                returnGrazeTime -= Time.deltaTime;
                if (returnGrazeTime < 0)
                {
                    grazeBool = true;
                    returnGrazeTime += ReturnGrazeStart;
                }
            }
        }
        //run method for different behaviour based on variable
        if (PlayerDistance < DistToFlee && fedBool == false)
        {
            //if (PlayerMovement.moveTotal >= PlayerMovement.moveTotal / 2)
            {
                grazeBool = false;
                idleBool = false;
                Flee();
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


    }


    void Flee()
    {
        if (target.position != FleePoint(transform.position))
        {
            target.position = FleePoint(transform.position);
            print("check");
        }
        agent.SetDestination(target.position);
        agent.isStopped = false;
        fleeBool = true;
    }

    void Follow()
    {
        if (targetDist <= 1)
        {
            target = Creature.transform;
        }
        else
        {
            target = Player.transform;
        }

        if(PlayerDistance >= 10)
        {
            grazeBool = true;
            fedBool = false;
        }
    }

    void Graze()
    {
        grazeTime -= Time.deltaTime;
        if (grazeTime < 0)
        {
            if(target.position != RandomPoint(transform.position))
            {
                target.position = FleePoint(transform.position);
                print(target.position + "actualCoords");
            }
            agent.SetDestination(target.position);
            agent.isStopped = false;
            grazeTime += grazeTimeStart;
        }
    }

    void Idle()
    {
        target = Creature.transform;
    }



    void runGrazeTimer()
    {
        grazeTime -= Time.deltaTime;
    }
    void runIdleTimer()
    {
        idleTime -= Time.deltaTime;
    }
}
