using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    bool spriteFlipped = false;

    void Update()
    {
        FollowMouse();
        FlipSprite();
        FollowMousePlayer();
    }

    private void FollowMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90);
    }

    private void FlipSprite()
    {
        if (Mathf.Abs(this.gameObject.transform.eulerAngles.z) > 90 && Mathf.Abs(this.gameObject.transform.eulerAngles.z) < 270 && !spriteFlipped)
        {
            transform.GetChild(0).localScale = new Vector3(-1, -1);
        }
        else
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1);
        }
    }

    private void FollowMousePlayer()
    {
        transform.position = this.gameObject.transform.parent.GetChild(0).position;
    }
}
