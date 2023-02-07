using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoSword : MeleeWeapons
{
    [SerializeField] MeleeWeaponScriptableObject weaponData;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        InputManager.InputMouseLeftEvent += ProtoSwordAttack;
    }

    private void ProtoSwordAttack(object source, InputMouseLeftArgs args)
    {
        Attack(animator, weaponData.swingDelay);
    }

    private void OnDestroy()
    {
        InputManager.InputMouseLeftEvent -= ProtoSwordAttack;
    }
}
