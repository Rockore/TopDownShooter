using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedWeaponsUI : MonoBehaviour
{
    [SerializeField] CurrentWeapon _CurrentWeapon;
    [SerializeField] AllWeaponsArray _AllWeaponArray;
    [SerializeField] Image currentWeaponUI;
    [SerializeField] Image otherWeaponUI;
    private GameObject currentWeapon;
    private GameObject otherWeapon;


    private void AddWeaponUI()
    {
        //To add weapon UI, if possible
    }

    private void RemoveWeaponUI()
    {
        //To remove weapon UI
    }

    private void SwapWeaponUI()
    {
        //For when picking up a new weapon
    }
}
