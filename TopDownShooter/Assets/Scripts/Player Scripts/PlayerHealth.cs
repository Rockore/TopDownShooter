using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public static int playerCurrentHealth;
    public static int playerMaxHealth;

    private void Start()
    {
        playerMaxHealth = 3;
        playerCurrentHealth = playerMaxHealth;
        healthSlider.maxValue = playerMaxHealth;
        healthSlider.value = playerCurrentHealth;
    }

    private void FixedUpdate()
    {
        healthSlider.value = playerCurrentHealth;
    }

    public static void AddHealth(int addedHealth)
    {
        playerCurrentHealth += addedHealth;
    }

    public static void RemoveHealth(int addedHealth)
    {
        playerCurrentHealth -= addedHealth;
    }

    public static void SetCurrentHealth(int health)
    {
        playerCurrentHealth = health;
    }

    public static void SetMaxHealth(int health)
    {
        playerMaxHealth = health;
    }
}
