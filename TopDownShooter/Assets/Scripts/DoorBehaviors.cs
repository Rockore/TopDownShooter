using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorBehaviors : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DoorManager.EnterDoor();
    }
}
