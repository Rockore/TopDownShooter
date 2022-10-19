using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    Rigidbody2D enemyRB;
    void Start()
    {
        health = 15;
        movementSpeed = 1f;
        enemyRB = this.GetComponent<Rigidbody2D>();
        enemyRB.gravityScale = 0;
    }

    void Update()
    {
        GoTowardsPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
    }
}
