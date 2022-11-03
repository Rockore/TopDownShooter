using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeRoom : MonoBehaviour
{
    private Vector3 roomPosition;
    private Vector3 previousRoomPosition;

    private void Start()
    {
        VisualizeStartingRoom();
    }

    private void VisualizeStartingRoom()
    {
        roomPosition = new Vector3(PlayerMovement.playerRoomPosition.x * 20 + GenerateFloorLayout.gridSizeX, PlayerMovement.playerRoomPosition.y * 15 + GenerateFloorLayout.gridSizeY);
        GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].floor.SetActive(true);
        GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].walls.SetActive(true);
        if(GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].topDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].topDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].rightDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].rightDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].bottomDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].bottomDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].leftDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].leftDoor.SetActive(true);
        previousRoomPosition = roomPosition;
    }

    private void VisualizeCurrentRoom(object source, GoThroughDoorArgs args)
    {
        roomPosition = new Vector3(PlayerMovement.playerRoomPosition.x * 20 + GenerateFloorLayout.gridSizeX, PlayerMovement.playerRoomPosition.y * 15 + GenerateFloorLayout.gridSizeY);
        GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].floor.SetActive(true);
        GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].walls.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].topDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].topDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].rightDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].rightDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].bottomDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].bottomDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].leftDoor)
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].leftDoor.SetActive(true);
        UnvisualizePreviousRoom();
        previousRoomPosition = roomPosition;
    }

    private void UnvisualizePreviousRoom()
    {
        if(previousRoomPosition == null)
        {
            return;
        }
        else
        {
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].floor.SetActive(false);
            GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].walls.SetActive(false);
            if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].topDoor)
                GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].topDoor.SetActive(false);
            if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].rightDoor)
                GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].rightDoor.SetActive(false);
            if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].bottomDoor)
                GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].bottomDoor.SetActive(false);
            if (GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].leftDoor)
                GenerateFloorLayout.rooms[(int)roomPosition.x, (int)roomPosition.y].leftDoor.SetActive(false);
        }
    }
}
