using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "GoldCoin")
        {
            PlayerMoney.AddMoney(1);
        }
        else if (gameObject.tag == "RedCoin")
        {
            PlayerMoney.AddMoney(5);
        }
        else if (gameObject.tag == "GreenCoin")
        {
            PlayerMoney.AddMoney(10);
        }
        Destroy(this.gameObject);
    }
}
