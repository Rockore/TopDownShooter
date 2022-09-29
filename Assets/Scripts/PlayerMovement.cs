using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void FixedUpdate()
    {
        Sprint();
        Movement();
        ClampToCamera();
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

    private void FollowMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90);
    }

    private void ClampToCamera()
    {
        if (this.gameObject.transform.position.x >= cameraWidth || this.gameObject.transform.position.x <= -cameraWidth || this.gameObject.transform.position.y >= cameraHeight || this.gameObject.transform.position.y <= -cameraHeight)
        {
            float x = Mathf.Clamp(this.gameObject.transform.position.x, -cameraWidth, cameraWidth);
            float y = Mathf.Clamp(this.gameObject.transform.position.y, -cameraHeight, cameraHeight);
            this.gameObject.transform.position = new Vector3(x, y);
        }
    }
}
