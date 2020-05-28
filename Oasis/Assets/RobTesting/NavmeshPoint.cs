using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshPoint : MonoBehaviour
{
    float range = 10f;
    public float timer;
    float curTime;

    Vector3 RandomPoint(Vector3 center, float range)
    {
        Vector3 result = center;
        for (int i = 0; i < 30;)
        {
            Vector2 TargetPoint = Random.insideUnitCircle* Random.Range(38, 800);
            Vector3 randomPoint = center + new Vector3 (TargetPoint.x, 0, TargetPoint.y);
            Debug.Log(randomPoint);
            return randomPoint;
        }
        return result;
    }

    private void Start()
    {
        curTime = timer;
    }

    private void Update()
    {
        Debug.Log(GetComponent<NavMeshAgent>().velocity);
        curTime -= Time.deltaTime;
        if (curTime < 0)
        {
            Debug.Log("startSearch");
            GetComponent<NavMeshAgent>().SetDestination(RandomPoint(transform.position, range));
            GetComponent<NavMeshAgent>().isStopped = false;
            curTime += timer;
        }
    }
}
