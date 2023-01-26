using System.Collections;
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
        if(GameObject.Find("DullSword") == null) 
            return;
        Attack(animator, weaponData.swingDelay);
    }
}
