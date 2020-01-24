using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [System.Serializable]
    public struct Waypoint
    {

        public Transform objTransform;
        public float travelTime;

    }

    public Waypoint[] waypoints;

    private Waypoint lastWaypoint, targetWaypoint;

    private float timer = 0f;

    void Awake()
    {
       
        if(waypoints.Length > 0)
        {
            lastWaypoint = waypoints[0];
        }

    }

    // Update is called once per frame
    void Update()
    {

        

        if (targetWaypoint.objTransform)
        {
            if (timer < 1f)
            {

                timer += Time.deltaTime / targetWaypoint.travelTime;
                transform.position = Vector3.Lerp(lastWaypoint.objTransform.position, targetWaypoint.objTransform.position, timer);

            }

            
        }

    }

    public void SetWaypoint(int waypointIndex)
    {

        if(waypointIndex >= waypoints.Length)
        {
            Debug.LogError("This waypoint doesn't exist!");
            return;
        }

        if (targetWaypoint.objTransform)
        {
            lastWaypoint = targetWaypoint;
        }

        targetWaypoint = waypoints[waypointIndex];
        timer = 0f;

    }
}
