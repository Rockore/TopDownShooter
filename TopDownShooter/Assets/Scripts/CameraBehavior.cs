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
        cam.transform.position = new Vector3(PlayerMovement.playerRoomPosition.x * 20, PlayerMovement.playerRoomPosition.y * 15);
        /*switch (args.Direction)
        {
            case "TopDoor":
                cam.transform.position = new Vector3(PlayerMovement.playerRoomPosition.x, PlayerMovement.playerRoomPosition.y * 15);
                break;
            case "RightDoor":
                cam.transform.position = new Vector3(PlayerMovement.playerRoomPosition.x * 20, PlayerMovement.playerRoomPosition.y);
                break;
            case "BottomDoor":
                cam.transform.position = new Vector3(PlayerMovement.playerRoomPosition.x, PlayerMovement.playerRoomPosition.y * -15);
                break;
            case "LeftDoor":
                cam.transform.position = new Vector3(PlayerMovement.playerRoomPosition.x * -20, PlayerMovement.playerRoomPosition.y);
                break;
            default:
                return;
        }*/
    }
}
