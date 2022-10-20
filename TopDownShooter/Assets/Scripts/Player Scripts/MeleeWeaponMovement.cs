using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponMovement : MonoBehaviour
{
    private bool spriteFlipped = false;
    private Transform shoulder;

    public float armLength = 1f; //Move this varible to MeleeWeapons

    void Start()
    {
        shoulder = transform.parent.GetChild(0).transform;
    }

    void Update()
    {
        FollowMouse();
        OrbitPlayer();
        //FlipSprite();
    }

    private void FollowMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    private void OrbitPlayer()
    {
        Vector3 shoulderToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shoulder.position;
        shoulderToMouseDir.z = 0;
        transform.position = shoulder.position + (armLength * shoulderToMouseDir.normalized);
    }

    private void FlipSprite()
    {
        //Fix this shit
        if (Mathf.Abs(this.gameObject.transform.eulerAngles.z) > 90 && Mathf.Abs(this.gameObject.transform.eulerAngles.z) < 270 && !spriteFlipped)
        {
            transform.GetChild(0).localScale = new Vector3(transform.GetChild(0).localScale.x, -transform.GetChild(0).localScale.y);
            spriteFlipped = true;
        }
    }
}
