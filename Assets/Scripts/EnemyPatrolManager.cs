using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyPatrolManager : MonoBehaviour
{
    [HideInInspector] public Transform target;

    [SerializeField] private PatrolWaypoints patrolWaypoints;
    [SerializeField] private float followTargetDistance;

    private int currentWaypoint;
    private float distanceToCurrentWaypoint;
    private EnemyMover enemyMover;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMover = GetComponent<EnemyMover>();
    }

    public bool InPatrolRange()
    {
        if (target == null) return false;

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance >= followTargetDistance) return false;
        else return true;
    }

    public void Patrol()
    {
        if (HasArrived())
        {
            currentWaypoint++;

            if (currentWaypoint == patrolWaypoints.waypoints.Count)
                currentWaypoint = 0;
        }
    }

    private bool HasArrived()
    {
        enemyMover.Move(patrolWaypoints.waypoints[currentWaypoint].position);

        distanceToCurrentWaypoint = Vector3.Distance(patrolWaypoints.waypoints[currentWaypoint].position, transform.position);

        if (distanceToCurrentWaypoint <= 0.2f)
        {
            return true;
        }
        return false;
    }
}
