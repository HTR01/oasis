using System.Collections;
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
    float dist, playerDist, targDist;
    [SerializeField] float fleeDist = 10;

    GameObject targetObj;
    GameObject attachedObj;
    Rigidbody rb;

    bool fleeBool, currentlyFleeing;
    bool newDir = false;
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
    float speed = 25;



    //Find Object within array furthest from current point
    GameObject getFurthestGO(List<GameObject> OBJSConsidered)
    {
        float furthestDist = 0;

        foreach (var obj in OBJSConsidered)
        {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            if (dist > furthestDist)
            {
                furthestDist = dist;
                furthestObj = obj;
            }
        }
        return furthestObj;
    }

    //Find a random spot in the area around a point
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

    //Find a random object within the desired array
    GameObject waypointPos(GameObject[] _selection)
    {
        index = Random.Range(0, _waypoints.Length);
        GameObject pos = _waypoints[index];
        return pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Assign everything
        attachedObj = this.gameObject;
        rb = attachedObj.GetComponent<Rigidbody>();
        fleeBool = false;
        _waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        targetSite = RandomPointOnTarget(transform.position);
        oldDir = Vector3.zero;
    }

    //Populate the waypoint list with the objects in the waypoint array
    IEnumerator PopList()
    {
        yield return new WaitForSeconds(0.1f);
        waypointList.AddRange(_waypoints);

        StopCoroutine("PopList");
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);

        waypointPos(_waypoints);
        
        //Assign targetObj to a random waypoint object. Assign target position to the transform position of the object
        if (targetObj == null)
        {
            targetObj = waypointPos(_waypoints);
        }
        else
        {
            target = targetObj.transform.position;
        }

        //Find distance between scriptholder and the position declared as being the target
        targDist = Vector3.Distance(transform.position, target);
        playerDist = Vector3.Distance(transform.position, player.transform.position);
        
        
        //On initializing, run the PopList coroutine to populate the waypointList
        if (waypointList.Count == 0)
        {
            StartCoroutine("PopList");
        }

         
        
            //movement (Constant)
       
        //Find Direction to target
        dir = (target - transform.position).normalized;
      
        
        //if there is nothing in old direction, set the rigidbody's velocity to the speed variable, multiplied by the direction to get to the target
        if (oldDir == Vector3.zero)
        {
            rb.velocity = dir * speed;
        }
        // if there is an Old direction, use a lerp to turn smoothly to face the new direction
        else
        {
            LerpTime();
            rb.velocity = Vector3.Lerp(oldDir, dir, t) * speed;
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
        
        

        //print(targetObj);
    }




    void Flee()
    {
        //If bool conditions are true, Find the furthest point away and flee in direction
        if (currentlyFleeing == false)
        {
            speed = 50;
            if (target != getFurthestGO(waypointList).transform.position)
            {
                checkForFurthest();
                currentlyFleeing = true;
            }
        }
        else if (currentlyFleeing == true && targDist < 1.5f)
        {
            speed = 25;
            currentlyFleeing = false;
            fleeBool = false;
        }
    }
    
    void Patrol()
    {
        //if object is within range, assign the old direction to current direction, then choose a new location to move to at random.
        if (targDist < 0.25f && newDir == false)
        {
            oldDir = dir;
            targetObj = waypointPos(_waypoints);
            target = targetObj.transform.position;
            newDir = true;
        }
        else
        {
            newDir = false;
        }
    }



    void checkForFurthest()
    {
        targetObj = getFurthestGO(waypointList);
        target = targetObj.transform.position;
    }



    void OnCollisionEnter(Collision col)
    {
        targetObj = waypointPos(_waypoints);
        target = targetObj.transform.position;
        //print("hit");
    }




    //Timer for lerping being direction and old direction
    void LerpTime()
    {
        t = Mathf.Clamp(t, 0, 1);
        if (t <= 1)
        {
            t += Time.deltaTime / 2;
        }
    }

}


