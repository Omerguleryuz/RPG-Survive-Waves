using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealth : Health
{
    public override void TakeDamage(int damage)
    {
        hp = Mathf.Max(hp - damage, 0);
        GetComponent<PlayerHealthBar>().UpdateHealthBar(hp, startingHealth);

        if (hp == 0)
            Die();
    }

    protected override void Die()
    {
        base.Die();

        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        ResetEnemyTargets();
    }

    private void ResetEnemyTargets()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyPatrolManager>().target = null;
        }
    }
}
