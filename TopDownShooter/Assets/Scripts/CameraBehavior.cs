using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        DoorBehaviors.GoThroughDoorEvent += ClampToRoom;
    }

    void Update()
    {
        
    }

    private void ClampToRoom(object source, GoThroughDoorArgs args)
    {
        cam.transform.position = new Vector3(PlayerMovement.playerRoomPosition.x * 20, PlayerMovement.playerRoomPosition.y * 15, -10);
    }
}
