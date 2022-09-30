using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    float currentMovementSpeed = 0.05f;
    float sprintMovementSpeed = 0.1f;
    float normalMovementSpeed = 0.05f;
    float cameraHeight;
    float cameraWidth;

    bool isCharacterFlipped;

    private void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;

        DoorBehaviors.GoThroughDoorEvent += MovePlayerRooms;
    }

    void FixedUpdate()
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

    public void MovePlayerRooms(object source, GoThroughDoorArgs args)
    {
        switch (args.Direction)
        {
            case "TopDoor":
                this.gameObject.transform.position += new Vector3(0, 9);
                break;
            case "RightDoor":
                this.gameObject.transform.position += new Vector3(6, 0);
                break;
            case "BottomDoor":
                this.gameObject.transform.position += new Vector3(0, -9);
                break;
            case "LeftDoor":
                this.gameObject.transform.position += new Vector3(-6, 0);
                break;
            default:
                return;
        }
    }
}
