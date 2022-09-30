using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
