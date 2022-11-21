using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    //enemy becomes awake, bring up exclamation mark
    //enemy chases after player
    bool coroutineCalled = false;
   
    bool colorchange = false;

    Vector2 direction;
    float distance;

    public Transform player;

    [SerializeField] float speed = 0.004f;

    public PlayerMovement pm;
    float damage;


    float health;
    public float maxHealth;

    public bool enemy1;
    public bool enemy2;
    public bool enemy3;
  
    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        damage = pm.damageDone;
        distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if(distance < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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

        if(health <= 0)
        {
            Die();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        health -= damage;
        colorchange = true;

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

    void Die()
    {
        if(enemy1)
        { pm.health++;
        }

        if(enemy2)
        {
            pm.health =+ 3;
        }

        if(enemy3)
        {
            pm.damageDone = +1;
            pm.health = +5;
        }
      
    }

}