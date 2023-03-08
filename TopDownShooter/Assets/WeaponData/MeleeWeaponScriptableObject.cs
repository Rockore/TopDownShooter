using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeaponScriptableObject", menuName = "Scriptable Objects/MeleeWeapon")]
public class MeleeWeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public string description;
    public Sprite weaponImage;
    public float damage;
    public float knockback;
    public float swingDelay;
    public float size;
    public String rarity;
}
