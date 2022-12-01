using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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
        PickObstacles(room);
        RemoveWallTilesForDoor(room);

        return room;
    }

    private void PickFloor(Room room)
    {
        switch (room.type)
        {
            case 0:
                room.floor = Instantiate(_RoomTemplates.normFloors[Random.Range(0, _RoomTemplates.normFloors.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 1:
                room.floor = Instantiate(_RoomTemplates.lootFloors[Random.Range(0, _RoomTemplates.lootFloors.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 2:
                room.floor = Instantiate(_RoomTemplates.bossFloors[Random.Range(0, _RoomTemplates.bossFloors.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 3:
                room.floor = Instantiate(_RoomTemplates.shopFloors[Random.Range(0, _RoomTemplates.shopFloors.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 4:
                room.floor = Instantiate(_RoomTemplates.blackFloors[Random.Range(0, _RoomTemplates.blackFloors.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
        }
    }

    private void PickWalls(Room room)
    {
        switch (room.type)
        {
            case 0:
                room.walls = Instantiate(_RoomTemplates.normWalls[Random.Range(0, _RoomTemplates.normWalls.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 1:
                room.walls = Instantiate(_RoomTemplates.lootWalls[Random.Range(0, _RoomTemplates.lootWalls.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 2:
                room.walls = Instantiate(_RoomTemplates.bossWalls[Random.Range(0, _RoomTemplates.bossWalls.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 3:
                room.walls = Instantiate(_RoomTemplates.shopWalls[Random.Range(0, _RoomTemplates.shopWalls.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
            case 4:
                room.walls = Instantiate(_RoomTemplates.blackWalls[Random.Range(0, _RoomTemplates.blackWalls.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                break;
        }
    }

    private void PickDoors(Room room)
    {
        if (room.type == 0)
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
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX + 1, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
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
        }

        else if(room.type > 0)
        {
            switch (room.doorValue)
            {
                //N/A
                case 0:
                    break;
                //T
                case 1:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //R
                case 2:
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TR
                case 3:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //B
                case 4:
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TB
                case 5:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //RB
                case 6:
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TRB
                case 7:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //L
                case 8:
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TL
                case 9:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //RL
                case 10:
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TRL
                case 11:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //BL
                case 12:
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TBL
                case 13:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //RBL
                case 14:
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TRBL
                case 15:
                    room.topDoor = Instantiate(_RoomTemplates.topDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.rightDoor = Instantiate(_RoomTemplates.rightDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.bottomDoor = Instantiate(_RoomTemplates.bottomDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    room.leftDoor = Instantiate(_RoomTemplates.leftDoor[(int)GenerateFloorLayout.rooms[(int)room.gridPos.x + GenerateFloorLayout.gridSizeX, (int)room.gridPos.y + GenerateFloorLayout.gridSizeY].type], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
            }
        }
    }

    private void PickObstacles(Room room)
    {
        if(room.gridPos.x == 0 && room.gridPos.y == 0)
        {
            room.obstacles = Instantiate(_RoomTemplates.spawnRoomObstacle, roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        }

        else if(room.type == 0)
        {
            switch (room.doorValue)
            {
                //T
                case 1:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue1[Random.Range(0, _RoomTemplates.obstaclesDoorValue1.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //R
                case 2:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue2[Random.Range(0, _RoomTemplates.obstaclesDoorValue2.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TR
                case 3:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue3[Random.Range(0, _RoomTemplates.obstaclesDoorValue3.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //B
                case 4:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue4[Random.Range(0, _RoomTemplates.obstaclesDoorValue4.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TB
                case 5:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue5[Random.Range(0, _RoomTemplates.obstaclesDoorValue5.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //RB
                case 6:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue6[Random.Range(0, _RoomTemplates.obstaclesDoorValue6.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TRB
                case 7:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue7[Random.Range(0, _RoomTemplates.obstaclesDoorValue7.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //L
                case 8:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue8[Random.Range(0, _RoomTemplates.obstaclesDoorValue8.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TL
                case 9:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue9[Random.Range(0, _RoomTemplates.obstaclesDoorValue9.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //RL
                case 10:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue10[Random.Range(0, _RoomTemplates.obstaclesDoorValue10.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TRL
                case 11:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue11[Random.Range(0, _RoomTemplates.obstaclesDoorValue11.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //BL
                case 12:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue12[Random.Range(0, _RoomTemplates.obstaclesDoorValue12.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TBL
                case 13:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue13[Random.Range(0, _RoomTemplates.obstaclesDoorValue13.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //RBL
                case 14:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue14[Random.Range(0, _RoomTemplates.obstaclesDoorValue14.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
                //TRBL
                case 15:
                    room.obstacles = Instantiate(_RoomTemplates.obstaclesDoorValue15[Random.Range(0, _RoomTemplates.obstaclesDoorValue15.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
                    break;
            }
        }

        else if (room.type == 1)
        {
            room.obstacles = Instantiate(_RoomTemplates.lootObstacles[Random.Range(0, _RoomTemplates.lootObstacles.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        }

        else if (room.type == 2)
        {
            room.obstacles = Instantiate(_RoomTemplates.bossObstacles[Random.Range(0, _RoomTemplates.bossObstacles.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        }

        else if (room.type == 3)
        {
            room.obstacles = Instantiate(_RoomTemplates.shopObstacles[Random.Range(0, _RoomTemplates.shopObstacles.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        }

        else if (room.type == 4)
        {
            room.obstacles = Instantiate(_RoomTemplates.blackObstacles[Random.Range(0, _RoomTemplates.blackObstacles.Length)], roomPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Grid").transform);
        }

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
