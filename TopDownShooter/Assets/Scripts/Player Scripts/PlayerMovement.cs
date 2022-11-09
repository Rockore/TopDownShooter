using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    private float currentMovementSpeed = 0.05f;
    private float sprintMovementSpeed = 0.1f;
    private float normalMovementSpeed = 0.05f;
=======
    private float currentMovementSpeed = 5f;
    private float sprintMovementSpeed = 10f;
    private float normalMovementSpeed = 5f;
>>>>>>> Stashed changes
    private float cameraHeight;
    private float cameraWidth;
    private bool isCharacterFlipped;

    public static Vector2 playerRoomPosition;

    private void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;

        DoorBehaviors.GoThroughDoorEvent += MovePlayerRooms;
    }

    private void Update()
    {
        Sprint();
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position += new Vector3(0, currentMovementSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position += new Vector3(-currentMovementSpeed, 0, 0);
            isCharacterFlipped = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position += new Vector3(0, -currentMovementSpeed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position += new Vector3(currentMovementSpeed, 0, 0);
            isCharacterFlipped = false;
        }

        if (isCharacterFlipped)
        {
            this.gameObject.transform.localScale = new Vector3(-1, this.gameObject.transform.localScale.y);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1, this.gameObject.transform.localScale.y);
        }
    }

    private void Sprint()
    {
        currentMovementSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintMovementSpeed : normalMovementSpeed;
    }

    private void MovePlayerRooms(object source, GoThroughDoorArgs args)
    {
        switch (args.Direction)
        {
            case "TopDoor":
                playerRoomPosition.y += 1;
                break;

            case "RightDoor":
                playerRoomPosition.x += 1;
                break;

            case "BottomDoor":
                playerRoomPosition.y -= 1;
                break;

            case "LeftDoor":
                playerRoomPosition.x -= 1;
                break;

            default:
                return;
        }
<<<<<<< Updated upstream
        this.gameObject.transform.position = new Vector3(playerRoomPosition.x * 20, playerRoomPosition.y * 15);
=======
        this.gameObject.transform.position = new Vector3(playerRoomPosition.x * 25, playerRoomPosition.y * 20);
>>>>>>> Stashed changes
    }
}
