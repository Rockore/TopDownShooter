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
        switch (args.Direction)
        {
            case "TopDoor":
                cam.transform.position += new Vector3(0, 15);
                break;
            case "RightDoor":
                cam.transform.position += new Vector3(20, 0);
                break;
            case "BottomDoor":
                cam.transform.position -= new Vector3(0, 15);
                break;
            case "LeftDoor":
                cam.transform.position -= new Vector3(20, 0);
                break;
            default:
                return;
        }
    }
}
