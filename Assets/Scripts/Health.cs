using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float startingHealth;
    [HideInInspector] public float hp;
    protected Animator animator;

    protected void Start()
    {
        animator = GetComponent<Animator>();
        hp = startingHealth;
    }
    
    public abstract void TakeDamage(int damage);

    protected virtual void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<Collider>().enabled = false;
    }
}
