using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] AllWeaponsArray _AllWeaponArray;
    [SerializeField] EquippedWeaponsUI _EquippedWeaponsUI;
    private GameObject currentWeapon;
    private float scrollTimer = 0;
    private int scrollNumber = 0;
    private bool weaponIsChanging;

    private void Update()
    {
        ChangeCurrentWeapon();
    }

    private void ChangeCurrentWeapon()
    {
        //Change UI weapon name while scrolling 
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            scrollNumber++;
            ScrollDelay();
            scrollTimer = 0;
            weaponIsChanging = true;

            if (scrollNumber > _AllWeaponArray.MeleeWeapons.Length - 1)
            {
                scrollNumber = 0;
            }
        }

        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            scrollNumber--;
            ScrollDelay();
            scrollTimer = 0;
            weaponIsChanging = true;

            if (scrollNumber > _AllWeaponArray.MeleeWeapons.Length - 1) 
            {
                scrollNumber = 0;
            }
            else if (scrollNumber < 0)
            {
                scrollNumber = _AllWeaponArray.MeleeWeapons.Length - 1;
            }
        }

        else if(Input.GetAxis("Mouse ScrollWheel") == 0 && weaponIsChanging == true)
        {
            scrollTimer += Time.deltaTime;

            if (scrollTimer >= .5f)
            {
                //Change UI image to current weapon
                weaponIsChanging = false;
            }
        }
    }

    private IEnumerator ScrollDelay()
    {
        yield return new WaitForSeconds(.1f);
    }
}
