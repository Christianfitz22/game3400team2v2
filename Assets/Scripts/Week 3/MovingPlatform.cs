using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath path;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int startingIndex;

    private int targetIndex;
    private Transform prevWaypoint;
    private Transform targetWaypoint;

    private float targetTime;
    private float elapsedTime;


    void Start()
    {
        FirstWaypoint();
    }

    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float elapsedProportion = elapsedTime / targetTime;
        transform.position = Vector3.Lerp(prevWaypoint.position, targetWaypoint.position, elapsedProportion);
        transform.rotation = Quaternion.Lerp(prevWaypoint.rotation, targetWaypoint.rotation, elapsedProportion);

        if (elapsedProportion >= 1)
        {
            NextWaypoint();
        }
    }

    private void FirstWaypoint()
    {
        prevWaypoint = path.GetWaypoint(startingIndex);
        targetIndex = path.GetNextPoint(startingIndex);
        targetWaypoint = path.GetWaypoint(targetIndex);
        elapsedTime = 0;
        float distance = Vector3.Distance(prevWaypoint.position, targetWaypoint.position);
        targetTime = distance / speed;
    }

    private void NextWaypoint()
    {
        prevWaypoint = path.GetWaypoint(targetIndex);
        targetIndex = path.GetNextPoint(targetIndex);
        targetWaypoint = path.GetWaypoint(targetIndex);
        elapsedTime = 0;
        float distance = Vector3.Distance(prevWaypoint.position, targetWaypoint.position);
        targetTime = distance / speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
