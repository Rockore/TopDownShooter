using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    BoxCollider2D spikeCollider;

    private void Start()
    {
        spikeCollider = GetComponent<BoxCollider2D>();
        spikeCollider.enabled = false;
    }


    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Feet")
        {
            if(this.gameObject.tag == "NormSpikes")
            {
                PlayerHealth.RemoveHealth(1);
            }
            else if (this.gameObject.tag == "RedSpikes")
            {
                PlayerHealth.SetCurrentHealth(1);
            }
            else if (this.gameObject.tag == "GoldSpikes")
            {
                PlayerMoney.RemoveMoney(1);
            }
        }
    }

    public void EnableSpikeCollider()
    {
        spikeCollider.enabled = true;
    }

    public void DisableSpikeCollider() 
    {
        spikeCollider.enabled = false;
    }
}
