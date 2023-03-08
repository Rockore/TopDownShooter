using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
        this.gameObject.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("PlayerBody").transform;
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

    /*public bool IsPlayerInRoom()
    {
        if ()
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/
}
