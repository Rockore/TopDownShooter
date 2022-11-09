using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeRoom : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] GenerateFloorLayout _GenerateFloorLayout;
    private GameObject previousFloor;
    private GameObject previousWalls;
    private GameObject previousDoors;
    private GameObject currentFloor;
    private GameObject currentWalls;
    private GameObject currentDoors;
=======
    Vector2 currentRoomPosition;
    Vector2 previousRoomPosition;
>>>>>>> Stashed changes

    private void Start()
    {
        DoorBehaviors.GoThroughDoorEvent += VisualizeCurrentRoom;
<<<<<<< Updated upstream
        VisualizeCurrentRoom(null, null);
=======
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
>>>>>>> Stashed changes
    }

    private void VisualizeCurrentRoom(object source, GoThroughDoorArgs args)
    {
<<<<<<< Updated upstream
        currentFloor = Instantiate(_GenerateFloorLayout.Rooms[(int)PlayerMovement.playerRoomPosition.x, (int)PlayerMovement.playerRoomPosition.y].floor);
        currentWalls = Instantiate(_GenerateFloorLayout.Rooms[(int)PlayerMovement.playerRoomPosition.x, (int)PlayerMovement.playerRoomPosition.y].walls);
        currentDoors = Instantiate(_GenerateFloorLayout.Rooms[(int)PlayerMovement.playerRoomPosition.x, (int)PlayerMovement.playerRoomPosition.y].doors);
        UnvisualizePreviousRoom();
=======
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
>>>>>>> Stashed changes
    }

    private void UnvisualizePreviousRoom()
    {
        if(previousFloor == null && previousWalls == null && previousDoors == null)
        {
            return;
        }
<<<<<<< Updated upstream
        Destroy(previousFloor);
        Destroy(previousWalls);
        Destroy(previousDoors);
=======
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
>>>>>>> Stashed changes
    }
}
