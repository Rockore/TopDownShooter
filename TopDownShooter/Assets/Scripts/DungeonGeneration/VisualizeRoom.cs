using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeRoom : MonoBehaviour
{
    [SerializeField] GenerateFloorLayout _GenerateFloorLayout;
    private GameObject previousFloor;
    private GameObject previousWalls;
    private GameObject previousDoors;
    private GameObject currentFloor;
    private GameObject currentWalls;
    private GameObject currentDoors;

    private void Start()
    {
        DoorBehaviors.GoThroughDoorEvent += VisualizeCurrentRoom;
        VisualizeCurrentRoom(null, null);
    }

    private void VisualizeCurrentRoom(object source, GoThroughDoorArgs args)
    {
        currentFloor = Instantiate(_GenerateFloorLayout.Rooms[(int)PlayerMovement.playerRoomPosition.x, (int)PlayerMovement.playerRoomPosition.y].floor);
        currentWalls = Instantiate(_GenerateFloorLayout.Rooms[(int)PlayerMovement.playerRoomPosition.x, (int)PlayerMovement.playerRoomPosition.y].walls);
        currentDoors = Instantiate(_GenerateFloorLayout.Rooms[(int)PlayerMovement.playerRoomPosition.x, (int)PlayerMovement.playerRoomPosition.y].doors);
        UnvisualizePreviousRoom();
    }

    private void UnvisualizePreviousRoom()
    {
        if(previousFloor == null && previousWalls == null && previousDoors == null)
        {
            return;
        }
        Destroy(previousFloor);
        Destroy(previousWalls);
        Destroy(previousDoors);
    }
}
