using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateRooms : MonoBehaviour
{
    [SerializeField] RoomTemplates _RoomTemplates;
    private Tilemap doorTilemap;
    private Tilemap wallTilemap;

    public Room CreateRoom(Room room)
    {
        PickFloor(room);
        PickWalls(room);
        PickDoors(room);
        RemoveWallTilesForDoor(room);

        return room;
    }

    private void PickFloor(Room room)
    {
        Debug.Log(_RoomTemplates == null);
        room.floor = _RoomTemplates.floors[Random.Range(0, _RoomTemplates.floors.Length)];
        Debug.Log("~Picked Floor");
    }

    private void PickWalls(Room room)
    {
        room.walls = _RoomTemplates.walls[Random.Range(0, _RoomTemplates.walls.Length)];
        Debug.Log("~Picked Walls");
    }

    private void PickDoors(Room room)
    {
        room.doors = _RoomTemplates.doors[Random.Range(0, _RoomTemplates.doors.Length)];
        Debug.Log("~Picked Doors");
    }

    private void RemoveWallTilesForDoor(Room room)
    {
        doorTilemap = room.doors.GetComponent<Tilemap>();
        wallTilemap = room.walls.GetComponent<Tilemap>(); 

        foreach (Vector3Int tilePosition in doorTilemap.cellBounds.allPositionsWithin)
        {
            wallTilemap.SetTile(tilePosition, null);
        }
        Debug.Log("~Removed Wall Tiles For Doors");
    }
}
