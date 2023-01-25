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
    private bool swingDelayed;

    public void Attack(Animator animator, float swingDelay)
    {
        if (swingDelayed)
            return;
        animator.SetTrigger("Attack");
        swingDelayed = true;
        StartCoroutine(DelaySwing(swingDelay));
    }

    private IEnumerator DelaySwing(float delay)
    {
        yield return new WaitForSeconds(delay);
        swingDelayed = false;
    }
}
