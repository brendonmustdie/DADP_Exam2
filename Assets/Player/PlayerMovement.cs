using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw(("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
    }
}
