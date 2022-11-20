using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    float health;
    float maxHealth = 100f;

    private void Start()
    {
        health = 100f;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(health >= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        health -= 5;
    }

    void Die()
    {
        //figure out what happens here. 
    }

    
}
