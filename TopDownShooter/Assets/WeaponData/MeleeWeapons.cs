using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeWeapons : MonoBehaviour
{
    public float damage;
    public float knockback;
    public float swingDelay;
    public float armLength;
    
    public Transform shoulder;
    public Animator animator;
    public bool swingDelayed;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void Attack()
    {
        if (swingDelayed)
            return;
        Attack();
        swingDelayed = true;
        StartCoroutine(DelaySwing(swingDelay));
    }

    private IEnumerator DelaySwing(float delay)
    {
        yield return new WaitForSeconds(delay);
        swingDelayed = false;
    }
}
