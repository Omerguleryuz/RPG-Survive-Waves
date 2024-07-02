using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Animator animator;
    private PlayerMover playerMover;
    private PlayerFighter playerFighter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerMover = GetComponent<PlayerMover>();
        playerFighter = GetComponent<PlayerFighter>();
    }

    private void Update()
    {
        playerFighter.Attack();
        playerMover.Rotate();
        playerMover.GetInput();

        if (playerFighter.IsAttacking()) return;

        playerMover.Move();
    }
}
