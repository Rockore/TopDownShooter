using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DullSword : MeleeWeapons
{
    [SerializeField] MeleeWeaponScriptableObject weaponData;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        InputManager.InputMouseLeftEvent += DullSwordAttack;
    }

    private void DullSwordAttack(object source, InputMouseLeftArgs args)
    {
        Attack(animator, weaponData.swingDelay);
    }
}
