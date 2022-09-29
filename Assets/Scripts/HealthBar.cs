using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Slider healthSlider;
    public float healthBarHeight;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.parent.GetChild(0).transform.position.x, this.gameObject.transform.parent.GetChild(0).transform.position.y + healthBarHeight);

        healthSlider.value = currentHealth/maxHealth;
        if(currentHealth == 0)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
