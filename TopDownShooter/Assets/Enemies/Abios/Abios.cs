using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abios : Enemy
{
    private Rigidbody2D enemyRB;

    private void Start()
    {
        health = 10;
        movementSpeed = 2f;
        enemyRB = this.GetComponent<Rigidbody2D>();
        enemyRB.gravityScale = 0;
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
    }
}
