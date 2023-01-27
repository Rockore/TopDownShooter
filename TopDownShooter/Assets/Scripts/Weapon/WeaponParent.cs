using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 mousePosition { get; set; }

    private void Update()
    {
        if (gameObject.transform.parent.localScale.x < 0)
        {
            MousePlayerLeft();
        }
        else if (gameObject.transform.parent.localScale.x > 0)
        {
            MousePlayerRight();
        }
    }

    private void MousePlayerLeft()
    {
        float offset = 90;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(-difference.y, -difference.x) * Mathf.Rad2Deg;
        if (rotationZ > 90 || rotationZ < -90)
        {
            if (rotationZ < 0)
            {
                rotationZ += 180;
            }
            else
            {
                rotationZ -= 180;
            }
            rotationZ = Mathf.Clamp(rotationZ, -45, 45);
        }
        else
        {
            rotationZ = Mathf.Clamp(rotationZ, -45, 45);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);
    }

    private void MousePlayerRight()
    {
        float offset = -90;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if(rotationZ > 90 || rotationZ < -90)
        {
            if(rotationZ < 0)
            {
                rotationZ += 180;
            }
            else
            {
                rotationZ -= 180;
            }
            rotationZ = Mathf.Clamp(rotationZ, -45, 45);
        }
        else
        {
            rotationZ = Mathf.Clamp(rotationZ, -45, 45);
        }
        
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);
    }
}
