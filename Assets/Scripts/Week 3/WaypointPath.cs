using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform GetWaypoint(int index)
    {
        return transform.GetChild(index);
    }

    public int GetNextPoint(int curIndex)
    {
        int nextIndex = curIndex + 1;
        if (nextIndex == transform.childCount)
        {
            nextIndex = 0;
        }
        return nextIndex;
    }
}
