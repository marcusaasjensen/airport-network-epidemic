using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public List<GameObject> ride;

    public int waitTime;
    public int speed;
    public int turnSpeed;
    public bool hasVirus;
    public bool checkInfection;
    public Airport currentAirport;

    void Start()
    {
        waitTime = Random.Range(1,12);        
        checkInfection = true;
        transform.position = ride[1].transform.position;
        StartCoroutine(TurnToFace(ride[0].transform.position));
        StartCoroutine(FollowPath(ride));
        //turnSpeed = 100*speed; simulation speed to implement later...
    }
    
    IEnumerator FollowPath(List<GameObject> waypoints)
    {
        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex].transform.position;
        transform.LookAt(targetWaypoint);
        while(true)
        {
            if(!(waypoints[targetWaypointIndex].GetComponent<Airport>().isBlocked) || currentAirport==null)
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if(transform.position == targetWaypoint)
            {
                currentAirport = waypoints[targetWaypointIndex].GetComponent<Airport>();
                if(!(currentAirport.isBlocked))
                {
                    targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Count;
                    targetWaypoint = waypoints[targetWaypointIndex].transform.position;
                    checkInfection = true;
                    yield return new WaitForSeconds(waitTime);
                    //checkInfection = false; // already false thanks to the infect function
                    yield return StartCoroutine(TurnToFace(targetWaypoint)); //wait for the coroutine to finish
                }
            }
            else
            {
                currentAirport = null;
            }
            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;
    
        while(Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle; //vector.up because the angle concerned is on the y axis (so only this axis has to have a value which is one)
            yield return null;
        }
    }


}
