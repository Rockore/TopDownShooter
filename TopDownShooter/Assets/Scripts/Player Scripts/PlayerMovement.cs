using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private float currentMovementSpeed = 5f;
    private float sprintMovementSpeed = 10f;
    private float normalMovementSpeed = 5f;
    private float cameraHeight;
    private float cameraWidth;
    private bool isCharacterFlipped;

    public static Vector2 playerRoomPosition;

    private void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;

        DoorBehaviors.GoThroughDoorEvent += MovePlayerRooms;

        InputManager.InputWEvent += MoveUp;
        InputManager.InputAEvent += MoveLeft;
        InputManager.InputSEvent += MoveDown;
        InputManager.InputDEvent += MoveRight;
    }

    private void Update()
    {
        Sprint();
    }

    private void MoveUp(object source, InputWArgs args)
    {
        this.gameObject.transform.position += new Vector3(0, currentMovementSpeed, 0) * Time.deltaTime;
    }
    private void MoveLeft(object source, InputAArgs args)
    {
        this.gameObject.transform.position += new Vector3(-currentMovementSpeed, 0, 0) * Time.deltaTime;
        isCharacterFlipped = true;
        CharacterFlip();
    }
    private void MoveDown(object source, InputSArgs args)
    {
        this.gameObject.transform.position += new Vector3(0, -currentMovementSpeed, 0) * Time.deltaTime;
    }
    private void MoveRight(object source, InputDArgs args)
    {
        this.gameObject.transform.position += new Vector3(currentMovementSpeed, 0, 0) * Time.deltaTime;
        isCharacterFlipped = false;
        CharacterFlip();
    }

    private void CharacterFlip()
    {
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
                this.gameObject.transform.position += new Vector3(0, 13);
                break;

            case "RightDoor":
                playerRoomPosition.x += 1;
                this.gameObject.transform.position += new Vector3(10, 0);
                break;

            case "BottomDoor":
                playerRoomPosition.y -= 1;
                this.gameObject.transform.position -= new Vector3(0, 13);
                break;

            case "LeftDoor":
                playerRoomPosition.x -= 1;
                this.gameObject.transform.position -= new Vector3(10, 0);
                break;

            default:
                return;
        }
    }
}
