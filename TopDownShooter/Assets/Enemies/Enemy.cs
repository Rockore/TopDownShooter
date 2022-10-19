using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float movementSpeed;
    public Vector3 enemyPosition;
    public Vector3 playerPosition;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void Idle()
    {

    }

    public void GoTowardsPlayer()
    {
        enemyPosition = this.transform.position;
        playerPosition = GameObject.FindGameObjectWithTag("PlayerBody").transform.position;
        this.transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, movementSpeed * Time.deltaTime);
    }

    public void MeleeAttack()
    {

    }

    public void RangeAttack()
    {

    }

    public void Die()
    {

    }
}
