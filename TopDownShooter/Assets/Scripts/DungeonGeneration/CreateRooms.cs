using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateRooms : MonoBehaviour
{
    [SerializeField] RoomTemplates _RoomTemplates;
    private Tilemap doorTilemap;
    private Tilemap wallTilemap;
    private Vector3 roomPosition;

    public Room CreateRoom(Room room)
    {
        roomPosition = new Vector3(room.gridPos.x * 25, room.gridPos.y * 20);
        PickFloor(room);
        PickWalls(room);
        PickDoors(room);
        RemoveWallTilesForDoor(room);

        return room;
    }

    private void PickFloor(Room room)
    {
<<<<<<< Updated upstream
        Debug.Log(_RoomTemplates == null);
        room.floor = _RoomTemplates.floors[Random.Range(0, _RoomTemplates.floors.Length)];
        Debug.Log("~Picked Floor");
=======
        room.floor = Instantiate(_RoomTemplates.floors[Random.Range(0, _RoomTemplates.floors.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        //room.floor.SetActive(false);
>>>>>>> Stashed changes
    }

    private void PickWalls(Room room)
    {
<<<<<<< Updated upstream
        room.walls = _RoomTemplates.walls[Random.Range(0, _RoomTemplates.walls.Length)];
        Debug.Log("~Picked Walls");
=======
        room.walls = Instantiate(_RoomTemplates.walls[Random.Range(0, _RoomTemplates.walls.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        //room.walls.SetActive(false);
>>>>>>> Stashed changes
    }

    private void PickDoors(Room room)
    {
<<<<<<< Updated upstream
        room.doors = _RoomTemplates.doors[Random.Range(0, _RoomTemplates.doors.Length)];
=======
        room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);

        //room.topDoor.SetActive(false);
        //room.rightDoor.SetActive(false);
        //room.bottomDoor.SetActive(false);
        //room.leftDoor.SetActive(false);
>>>>>>> Stashed changes
        Debug.Log("~Picked Doors");
    }

    private void RemoveWallTilesForDoor(Room room)
    {
<<<<<<< Updated upstream
        doorTilemap = room.doors.GetComponent<Tilemap>();
        wallTilemap = room.walls.GetComponent<Tilemap>(); 

        foreach (Vector3Int tilePosition in doorTilemap.cellBounds.allPositionsWithin)
        {
            wallTilemap.SetTile(tilePosition, null);
=======
        wallTilemap = room.walls.GetComponent<Tilemap>();

        if (room.topDoor != null)
        {
            topDoorTilemap = room.topDoor.GetComponent<Tilemap>();
            foreach (Vector3Int tilePosition in topDoorTilemap.cellBounds.allPositionsWithin)
            {
                if(topDoorTilemap.GetTile(tilePosition) != null)
                    wallTilemap.SetTile(tilePosition, null);
            }
        }
            
        if (room.rightDoor != null)
        {
            rightDoorTilemap = room.rightDoor.GetComponent<Tilemap>();
            foreach (Vector3Int tilePosition in rightDoorTilemap.cellBounds.allPositionsWithin)
            {
                if (rightDoorTilemap.GetTile(tilePosition) != null)
                    wallTilemap.SetTile(tilePosition, null);
            }
        }

        if (room.bottomDoor != null)
        {
            bottomDoorTilemap = room.bottomDoor.GetComponent<Tilemap>();
            foreach (Vector3Int tilePosition in bottomDoorTilemap.cellBounds.allPositionsWithin)
            {
                if (bottomDoorTilemap.GetTile(tilePosition) != null)
                    wallTilemap.SetTile(tilePosition, null);
            }
        }

        if (room.leftDoor != null)
        {
            leftDoorTilemap = room.leftDoor.GetComponent<Tilemap>();
            foreach (Vector3Int tilePosition in leftDoorTilemap.cellBounds.allPositionsWithin)
            {
                if (leftDoorTilemap.GetTile(tilePosition) != null)
                    wallTilemap.SetTile(tilePosition, null);
            }
>>>>>>> Stashed changes
        }
        Debug.Log("~Removed Wall Tiles For Doors");
    }
}
