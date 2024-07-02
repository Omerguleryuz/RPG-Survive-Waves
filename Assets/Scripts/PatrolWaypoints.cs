using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWaypoints : MonoBehaviour
{
    [HideInInspector] public List<Transform> waypoints;
    void Start()
    {
        AddWaypoints();
    }

    private void AddWaypoints()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            waypoints.Add(transform.GetChild(i));
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int nextPoint = i + 1;
            if (nextPoint >= transform.childCount)
            {
                nextPoint = 0;
            }

            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(nextPoint).position);
        }
    }
}
