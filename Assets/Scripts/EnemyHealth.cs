using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : Health
{
    public override void TakeDamage(int damage)
    {
        hp = Mathf.Max(hp - damage, 0);
        GetComponent<EnemyHealthBar>().UpdateHealthBar(hp, startingHealth);

        if (hp == 0)
            Die();
    }

    protected override void Die()
    {
        base.Die();

        if (GetComponent<EnemyHealthBar>())
            GetComponent<EnemyHealthBar>().healthBarCanvas.enabled = false;

        GetComponent<EnemyController>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
