using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyArgs : EventArgs
{
    public int PlayerCurrentMoney { get; set; }
}

public class PlayerMoney : MonoBehaviour
{
    public delegate void MoneyDelegate(object source, MoneyArgs args);
    public static event MoneyDelegate MoneyEvent;

    public static int playerCurrentMoney;

    public void Start()
    {
        playerCurrentMoney = 0;
    }

    private void Update()
    {
        
    }

    public static void RemoveMoney(int amount)
    {
        playerCurrentMoney -= amount;
        UpdateMoney();
    }

    public static void AddMoney(int amount)
    {
        playerCurrentMoney += amount;
        UpdateMoney();
    }

    public static void SetMoney(int amount)
    {
        playerCurrentMoney = amount;
        UpdateMoney();
    }

    private static void UpdateMoney()
    {
        MoneyEvent?.Invoke(null, new MoneyArgs() { PlayerCurrentMoney = playerCurrentMoney});
    }
}
