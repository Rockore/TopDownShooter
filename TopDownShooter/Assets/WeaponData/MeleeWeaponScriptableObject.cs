using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeleeWeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public string description;
    public float damage;
    public float knockback;
    public float swingDelay;
    public float armLength;
    public String rarity;
}
