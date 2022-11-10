using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeRoom : MonoBehaviour
{
    Vector2 currentRoomPosition;
    Vector2 previousRoomPosition;

    private void Start()
    {
        DoorBehaviors.GoThroughDoorEvent += VisualizeCurrentRoom;
        VisualizeStartingRoom(null, null);
    }

    private void VisualizeStartingRoom(object source, GoThroughDoorArgs args)
    {
        currentRoomPosition = new Vector2(PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY);
        GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].floor.SetActive(true);
        GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].walls.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].topDoor)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].topDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].rightDoor)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].rightDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].bottomDoor)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].bottomDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].leftDoor)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].leftDoor.SetActive(true);
        previousRoomPosition = currentRoomPosition;
    }

    private void VisualizeCurrentRoom(object source, GoThroughDoorArgs args)
    {
        currentRoomPosition = new Vector2(PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY);

        GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].floor.SetActive(true);
        GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].walls.SetActive(true);
        if(GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].topDoor != null)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].topDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].rightDoor != null)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].rightDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].bottomDoor != null)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX, (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].bottomDoor.SetActive(true);
        if (GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].leftDoor != null)
            GenerateFloorLayout.rooms[(int)PlayerMovement.playerRoomPosition.x + GenerateFloorLayout.gridSizeX , (int)PlayerMovement.playerRoomPosition.y + GenerateFloorLayout.gridSizeY].leftDoor.SetActive(true);
        //UnvisualizePreviousRoom();
        previousRoomPosition = currentRoomPosition;
    }

    private void UnvisualizePreviousRoom()
    {
        GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].floor.SetActive(false);
        GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].walls.SetActive(false);
        if (GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].topDoor != null)
            GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].topDoor.SetActive(false);
        if (GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].rightDoor != null)
            GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].rightDoor.SetActive(false);
        if (GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].bottomDoor != null)
            GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].bottomDoor.SetActive(false);
        if (GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].leftDoor != null)
            GenerateFloorLayout.rooms[(int)previousRoomPosition.x, (int)previousRoomPosition.y].leftDoor.SetActive(false);
    }
}
