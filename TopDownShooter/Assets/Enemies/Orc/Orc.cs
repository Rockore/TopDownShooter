using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    private Rigidbody2D enemyRB;
    private void Start()
    {
        health = 15;
        movementSpeed = 1f;
        enemyRB = this.GetComponent<Rigidbody2D>();
        enemyRB.gravityScale = 0;
    }

    private void Update()
    {
        GoTowardsPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
    }
}
