using System.Collections;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [HideInInspector] public float timeAfterLastAttack = Mathf.Infinity;
    [HideInInspector] public bool isAttacking;
    [SerializeField] protected float attackTimeInterval;

    protected Rigidbody rb;
    protected Animator animator;
    

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    public abstract void Attack();

    public abstract bool IsAttacking();

    public abstract IEnumerator ResetAttackBool();
}
