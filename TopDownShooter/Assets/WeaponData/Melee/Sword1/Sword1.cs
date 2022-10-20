using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1 : MeleeWeapons
{

    private void Start()
    {
        damage = 1;
        knockback = 0.5f;
        swingDelay = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Swing(swingDelay);
        }
    }
}
