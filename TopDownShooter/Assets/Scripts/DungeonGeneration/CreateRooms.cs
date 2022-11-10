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
        switch (room.doorValue)
        {
            //N/A
            case 0:
                break;
            //T
            case 1:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //R
            case 2:
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //TR
            case 3:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //B
            case 4:
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //TB
            case 5:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //RB
            case 6:
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //TRB
            case 7:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //L
            case 8:
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //TL
            case 9:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //RL
            case 10:
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //TRL
            case 11:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //BL
            case 12:
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //TBL
            case 13:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //RBL
            case 14:
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            //TRBL
            case 15:
                room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY + 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY - 1].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX - 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
        }

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
