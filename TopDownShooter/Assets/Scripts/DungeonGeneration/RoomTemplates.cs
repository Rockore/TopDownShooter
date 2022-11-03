using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    //Door Type Values:
    // 0. Normal
    // 1. Loot
    // 2. Boss
    // 3. Shop
    // 4. Blacksmith

    public GameObject[] floors;
    public GameObject[] walls;
    public GameObject[] topDoors;
    public GameObject[] rightDoors;
    public GameObject[] bottomDoors;
    public GameObject[] leftDoors;
    public GameObject[] roomTypeIcons;
}
