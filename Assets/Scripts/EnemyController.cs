using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyMover enemyMover;
    private EnemyPatrolManager enemyPatrolManager;
    private EnemyFighter enemyFighter;

    private void Start()
    {
        enemyMover = GetComponent<EnemyMover>();
        enemyPatrolManager = GetComponent<EnemyPatrolManager>();
        enemyFighter = GetComponent<EnemyFighter>();
    }
    
    private void Update()
    {
        if (enemyPatrolManager.InPatrolRange())
        {
            if (enemyFighter.InAttackRange())
            {
                enemyMover.Stop();
                enemyFighter.Attack();
                
                if (!enemyFighter.IsAttacking())
                {
                    enemyMover.Rotate();
                }
            }
            else
            {

                enemyMover.Move(enemyMover.target.position);
                enemyMover.Rotate();
            }
        }
        else
        {
            enemyPatrolManager.Patrol();
            //enemyMover.Stop();
        }

        enemyFighter.timeAfterLastAttack += Time.deltaTime;
    }
}
