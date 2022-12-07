using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 mousePosition { get; set; }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        FlipSprite(rotationZ);
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    private void FlipSprite(float rotation)
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Fix This~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Vector2 scale = transform.localScale;
        if (rotation < 90)
        {
            scale.y = -1f;
        }
        else if (rotation > -90)
        {
            scale.y = 1f;
        }
        transform.localScale = scale;
    }
}
