using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapons : MonoBehaviour
{
    public float damage;
    public float knockback;
    public float swingDelay;

    Animator animator;
    private bool swingDelayed;
    
    public void Swing(float delay)
    {
        animator = GetComponentInParent<Animator>();
        if (swingDelayed)
            return;
        animator.SetTrigger("Attack");
        swingDelayed = true;
        StartCoroutine(DelaySwing(delay));
    }

    private IEnumerator DelaySwing(float delay)
    {
        yield return new WaitForSeconds(delay);
        swingDelayed = false;
    }
}
