using UnityEngine;

public class PlayerMover : Mover
{
    private Vector3 movement;


    public override void Move()
    {
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    public override void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.eulerAngles += new Vector3(0, mouseX, 0);
        }
    }

    public void GetInput()
    {
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * moveSpeed;
            animator.SetFloat("Speed", 2, 0.2f, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward * moveSpeed;
            animator.SetFloat("Speed", -2, 0.2f, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right * moveSpeed;
            animator.SetFloat("Horizontal", 2, 0.2f, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right * moveSpeed;
            animator.SetFloat("Horizontal", -2, 0.2f, Time.deltaTime);
        }

        if (movement.z <= 0.05f)
        {
            animator.SetFloat("Speed", 0, 0.2f, Time.deltaTime);
        }
        if (movement.x <= 0.05f)
        {
            animator.SetFloat("Horizontal", 0, 0.2f, Time.deltaTime);
        }
    }
}
