using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    private Transform target;
    private int wayPointIndex = 0;
    [HideInInspector] public float speed;


    private void Start()
    {
        //CODE FOR MOVING THE BALLOON
        target = WayPoints.wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        //CODE FOR MOVING THE BALLOON
        Vector3 dir = target.position - transform.position;
        GetComponentInParent<Transform>().Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(target.position, transform.position) <= .4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wayPointIndex >= WayPoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;//makes sure the Destroy method is complete before continuing with the code
        }

        wayPointIndex++;
        target = WayPoints.wayPoints[wayPointIndex];
    }
}
