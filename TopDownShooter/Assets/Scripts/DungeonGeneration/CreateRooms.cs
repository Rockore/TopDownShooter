using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateRooms : MonoBehaviour
{
    [SerializeField] RoomTemplates _RoomTemplates;
    private Tilemap topDoorTilemap;
    private Tilemap rightDoorTilemap;
    private Tilemap bottomDoorTilemap;
    private Tilemap leftDoorTilemap;
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
        room.floor = Instantiate(_RoomTemplates.floors[Random.Range(0, _RoomTemplates.floors.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        //room.floor.SetActive(false);
    }

    private void PickWalls(Room room)
    {
        room.walls = Instantiate(_RoomTemplates.walls[Random.Range(0, _RoomTemplates.walls.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        //room.walls.SetActive(false);
    }

    private void PickDoors(Room room)
    {
        room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);  
        room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)room.type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);

        //room.topDoor.SetActive(false);
        //room.rightDoor.SetActive(false);
        //room.bottomDoor.SetActive(false);
        //room.leftDoor.SetActive(false);
    }

    private void RemoveWallTilesForDoor(Room room)
    {
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
        }
    }
}
