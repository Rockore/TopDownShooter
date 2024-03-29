using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoThroughDoorArgs : EventArgs
{
    public string Direction { get; set; }
}

public class DoorBehaviors : MonoBehaviour
{
    public delegate void GoThroughDoorDelegate(object source, GoThroughDoorArgs args);
    public static event GoThroughDoorDelegate GoThroughDoorEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody")
        {
            Debug.Log(collision.gameObject.tag);
            Debug.Log("Triggered Door");
            OpenDoorAnimate();
            GoThroughDoor(this.gameObject.tag);
        }
    }
    
    public static void GoThroughDoor(string tag)
    {
        GoThroughDoorEvent?.Invoke(null, new GoThroughDoorArgs() { Direction = tag});
    }

    private void OpenDoorAnimate()
    {

    }
}
