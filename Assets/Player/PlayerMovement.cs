using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    bool coroutineCalled = false;
    public float walkSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    float health;
    float maxHealth = 25f;

    public Image healthImge;

    
    bool colorchange = false;

    private void Start()
    {
        health = 25f;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        healthImge.fillAmount = health / maxHealth;

        if (health >= 0)
        {
            Die();
        }

     

        if (colorchange)
        {
            if (!coroutineCalled)
            {
                StartCoroutine("color");
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
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
        colorchange = true;



    }

    void Die()
    {
        //figure out what happens here. 
    }

    IEnumerator color()
    {
        while (colorchange)
        {
            coroutineCalled = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            yield return new WaitForSeconds(0.3f);
            StopFlash();
        }
        coroutineCalled = false;
    }

    void StopFlash()
    {
        colorchange = false;
    }


}
