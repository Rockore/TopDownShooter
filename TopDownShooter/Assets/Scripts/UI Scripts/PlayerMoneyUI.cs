using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerMoneyUI : MonoBehaviour
{
    private TextMeshProUGUI moneyAmountText;
    //[SerializeField] TextMeshPro moneyAmountText;

    void Start()
    {
        moneyAmountText = gameObject.GetComponent<TextMeshProUGUI>();
        PlayerMoney.MoneyEvent += UpdateMoneyUIAmount;
    }

    void Update()
    {
        
    }

    public void UpdateMoneyUIAmount(object source, MoneyArgs args)
    {
        moneyAmountText.SetText(Convert.ToString(args.PlayerCurrentMoney));
    }
}
