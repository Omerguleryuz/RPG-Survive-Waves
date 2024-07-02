using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : Mover
{
    [HideInInspector] public Transform target;

    private NavMeshAgent agent;


    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Move(Vector3 targetPosition)
    {
        agent.destination = targetPosition;
        animator.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
        agent.isStopped = false;
    }

    public override void Rotate()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        Vector3 currentDirection = transform.forward;
        Vector3 newDirection = Vector3.RotateTowards(currentDirection, direction, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void Stop()
    {
        animator.SetFloat("Speed", 0f, 0.2f, Time.deltaTime);
        agent.isStopped = true;
    }
}
