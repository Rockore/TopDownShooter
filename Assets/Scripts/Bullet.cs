using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>() != null)
        {
            return;
        }
        if(collision.gameObject.GetComponent<EnemyAI>() != null)
        {
            
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
