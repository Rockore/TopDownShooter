using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorManager : MonoBehaviour
{
    public static event Action EnterDoorEvent;
    
    public static void EnterDoor()
    {
        EnterDoorEvent?.Invoke();
    }
}
