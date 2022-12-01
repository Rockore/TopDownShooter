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
        Debug.Log("Triggered Spike Collidier");
        if(collision.tag == "PlayerBody")
        {
            Debug.Log("Spike collidied with player");
            if(this.gameObject.tag == "NormSpikes")
            {
                Debug.Log("Player Hit NormSpike");
                PlayerHealth.RemoveHealth(1);
            }
            else if (this.gameObject.tag == "RedSpikes")
            {
                Debug.Log("Player Hit RedSpikes");
                PlayerHealth.SetCurrentHealth(1);
            }
            else if (this.gameObject.tag == "GoldSpikes")
            {
                Debug.Log("Player Hit GoldSpikes");
                Debug.Log("Removed 1 gold from player");
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
