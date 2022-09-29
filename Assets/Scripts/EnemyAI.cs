using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyData enemyData;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;
    private Vector3 positionDifference;
    PlayerHealth _PlayerHealth;

    private float enemyHealth;

    private void Start()
    {
        _PlayerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        GoTowardsPlayer();
    }

    private void GoTowardsPlayer()
    {
        playerPosition = GameObject.FindGameObjectWithTag("PlayerBody").transform.position;
        enemyPosition = this.gameObject.transform.position;
        positionDifference = playerPosition - enemyPosition;
        positionDifference.Normalize();
        Rigidbody2D enemyRb = this.gameObject.GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = Vector2.MoveTowards(transform.position, playerPosition, enemyData.speed * Time.deltaTime);
        enemyRb.AddForce(positionDifference * enemyData.speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>() != null)
        {
            //enemyData.health -= collision.gameObject.GetComponent<Bullet>().bulletData.damage;
        }
    }
}
