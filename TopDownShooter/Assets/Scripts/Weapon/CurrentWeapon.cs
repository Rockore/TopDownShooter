using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] AllWeaponsArray _AllWeaponArray;
    [SerializeField] EquippedWeaponsUI _EquippedWeaponsUI;
    private MeleeWeaponScriptableObject currentWeapon;
    private MeleeWeaponScriptableObject otherWeapon;
    private float scrollTimer = 0;
    private bool weaponIsChanging;

    private void Update()
    {
        ChangeCurrentWeapon();
    }

    private void ChangeCurrentWeapon()
    {
        //Change UI weapon name while scrolling 
        //``````````````````````````````MAKE IT SO IT CYCLES THROUGH EQUIPPED WEAPONS```````````````````````````````
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ScrollDelay();
            scrollTimer = 0;
        }

        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ScrollDelay();
            scrollTimer = 0;
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
