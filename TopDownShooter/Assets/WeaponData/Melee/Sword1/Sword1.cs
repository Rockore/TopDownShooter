using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1 : MeleeWeapons
{

    void Start()
    {
        damage = 1;
        knockback = 0.5f;
        swingRate = 1;
    }

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            SwingWeapon();
        }
    }
}
