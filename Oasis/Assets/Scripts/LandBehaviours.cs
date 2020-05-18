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

    //Objects
    GameObject Player;
    GameObject Creature;
    NavMeshAgent agent;

    //Timers
    float grazeTime, grazeTimeStart;
    float idleTime, idleTimeStart;
    float returnGrazeTime, ReturnGrazeStart;
    // Start is called before the first frame update
    void Start()
    {
        fedBool = false;
        grazeBool = true;
        idleBool = false;
        Player = GameObject.Find("Player");
        Creature = this.gameObject;
        agent = Creature.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        //get distance values
        PlayerDistance = Vector3.Distance(Player.transform.position, Creature.transform.position);
        targetDist = Vector3.Distance(target.transform.position, Creature.transform.position);

        


        //run method for different behaviour based on variable
        if (PlayerDistance < DistToFlee && PlayerMovement.moveTotal >= PlayerMovement.moveTotal / 2 && fedBool == false)
        {
            grazeBool = false;
            idleBool = false;
            Flee();
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
        /*
        Set target to location between minplayerdist and maxplayerdist within Land Navmesh
        moveto target * (speed * 1.5)

        if (location reach)
        {
            end flee
            run graze
        }
        */
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
        if(targetDist <= 1)
        {
            runGrazeTimer();
            if(grazeTime <= 0.05)
            {
                grazeTime = grazeTimeStart;
                //target.position = 
                //set target to random location in navmesh
            }
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
    void runGrazeReturnTimer()
    {
        returnGrazeTime -= Time.deltaTime;
    }
    void runIdleTimer()
    {
        idleTime -= Time.deltaTime;
    }
}
