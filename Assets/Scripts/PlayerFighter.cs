using System.Collections;
using UnityEngine;

public class PlayerFighter : Fighter
{

    public override void Attack()
    {
        timeAfterLastAttack += Time.deltaTime;
        if (timeAfterLastAttack < attackTimeInterval) return;


        if (Input.GetMouseButtonDown(0))
        {
            timeAfterLastAttack = 0;
            animator.SetTrigger("Attack");
            isAttacking = true;
            animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
            animator.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);

            rb.velocity = Vector3.zero;

            StartCoroutine(ResetAttackBool());
        }
    }
    public override bool IsAttacking()
    {
        return isAttacking;
    }

    public override IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(attackTimeInterval);
        animator.ResetTrigger("Attack");
        isAttacking = false;
    }
}
