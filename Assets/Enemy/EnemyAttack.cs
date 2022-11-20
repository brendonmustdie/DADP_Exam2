using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //if player enters trigger,
    //enemy becomes awake, bring up exclamation mark
    //enemy chases after player

    Vector2 direction;

    public Transform player;

    float speed = 3f;

    bool triggered;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }

    private void Update()
    {
        if (triggered)
        {
            direction = player.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
        }
    }
}
