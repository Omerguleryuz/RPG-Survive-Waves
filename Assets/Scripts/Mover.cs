using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 6f;

    protected Rigidbody rb;
    protected Animator animator;
    protected float rotationSpeed = 3f;


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public virtual void Move() { }

    public abstract void Rotate();
}
