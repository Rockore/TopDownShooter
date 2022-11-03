using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        DoorBehaviors.GoThroughDoorEvent += ClampToRoom;
    }

    private void Update()
    {
        
    }

    private void ClampToRoom(object source, GoThroughDoorArgs args)
    {
        cam.transform.position = new Vector3(PlayerMovement.playerRoomPosition.x * 25, PlayerMovement.playerRoomPosition.y * 15, -10);
    }
}
