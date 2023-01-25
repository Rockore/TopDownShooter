using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        DoorBehaviors.GoThroughDoorEvent += MoveCameraToRoom;
    }

    private void MoveCameraToRoom(object source, GoThroughDoorArgs args)
    {
        switch (args.Direction)
        {
            case "TopDoor":
                StartCoroutine(cameraUp());
                break;

            case "RightDoor":
                StartCoroutine(cameraRight());
                break;

            case "BottomDoor":
                StartCoroutine(cameraDown());
                break;

            case "LeftDoor":
                StartCoroutine(cameraLeft());
                break;

            default:
                return;
        }
    }

    private IEnumerator cameraUp()
    {
        for (int i = 0; i < 20; i++)
        {
            cam.transform.position += new Vector3(0, 1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    private IEnumerator cameraRight()
    {
        for (int i = 0; i < 25; i++)
        {
            cam.transform.position += new Vector3(1, 0);
            yield return new WaitForSecondsRealtime(0.0075f);
        }
    }

    private IEnumerator cameraDown()
    {
        for (int i = 0; i < 20; i++)
        {
            cam.transform.position -= new Vector3(0, 1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    private IEnumerator cameraLeft()
    {
        for (int i = 0; i < 25; i++)
        {
            cam.transform.position -= new Vector3(1, 0);
            yield return new WaitForSecondsRealtime(0.0075f);
        }
    }
}
