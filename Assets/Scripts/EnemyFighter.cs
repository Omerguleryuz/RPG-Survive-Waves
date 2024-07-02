using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFighter : Fighter
{
    [SerializeField] private float attackRange;

    private Transform target;
    private NavMeshAgent agent;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Attack()
    {
        animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);

        if (timeAfterLastAttack < attackTimeInterval) return;

        timeAfterLastAttack = 0;
        animator.SetTrigger("Attack");
        agent.isStopped = true;
        isAttacking = true;
        StartCoroutine(ResetAttackBool());
    }

    public override bool IsAttacking()
    {
        return isAttacking;
    }

    public override IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(attackTimeInterval);
        animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        isAttacking = false;
    }

    public bool InAttackRange()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance >= attackRange) return false;
        else return true;
    }
}
