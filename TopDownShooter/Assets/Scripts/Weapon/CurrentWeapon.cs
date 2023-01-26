using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] AllWeaponsArray _AllWeaponArray;
    public GameObject currentWeapon;
    private float scrollTimer = 0;
    private int scrollNumber = 0;

    private void Start()
    {
        SpawnWeapon(_AllWeaponArray.MeleeWeapons[0]);
    }

    private void Update()
    {
        ChangeCurrentWeapon();
    }

    private void SpawnWeapon(GameObject weapon)
    {
        Debug.Log("Spawning: " + weapon.name);
        currentWeapon = Instantiate(weapon,this.gameObject.transform.parent);
    }

    private void DestroyWeapon(GameObject weapon)
    {
        Debug.Log("Destroy: " + weapon.name);
        Destroy(weapon);
    }

    private void ChangeCurrentWeapon()
    {

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log("Scroll Up");
            scrollNumber++;
            ScrollDelay();
            scrollTimer = 0;
        }

        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("Scroll Down");
            scrollNumber--;
            ScrollDelay();
            scrollTimer = 0;
        }

        else if(Input.GetAxis("Mouse ScrollWheel") == 0)
        {
            Debug.Log("Scroll Number: " + scrollNumber);
            scrollTimer += Time.deltaTime;
            ScrollTimerDelay();
            if (scrollTimer >= 2)
            {
                DestroyWeapon(currentWeapon);
                if(scrollNumber > _AllWeaponArray.MeleeWeapons.Length)
                {
                    scrollNumber = scrollNumber % _AllWeaponArray.MeleeWeapons.Length;
                }
                SpawnWeapon(_AllWeaponArray.MeleeWeapons[scrollNumber]);
            }
        }
    }

    private IEnumerator ScrollDelay()
    {
        yield return new WaitForSeconds(.1f);
    }

    private IEnumerator ScrollTimerDelay()
    {
        Debug.Log("ScrollTimer: " + scrollTimer);
        yield return new WaitForSeconds(1f);
    }
}
