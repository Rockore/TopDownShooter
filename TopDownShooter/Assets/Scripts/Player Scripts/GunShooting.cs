using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] Animator animator;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    private float timer;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        ShootGun();
    }

    private void ShootGun()
    {
        if (Input.GetMouseButton(0))
        {
            if (timer > 1 / (gunData.fireRate / 60))
            {
                animator.Play("MuzzleFlash", 0, 0f);
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D bulletRd = bullet.GetComponent<Rigidbody2D>();
                bulletRd.AddForce(firePoint.right * gunData.projectileSpeed, ForceMode2D.Impulse);
                timer = 0;
            }   
        }
    }
}



