using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRooms : MonoBehaviour
{
    //2D array of rooms
    Room[,] rooms;

    //List of taken positions
    List<Vector2> takenPositions = new List<Vector2>();

    //The grid size
    public int gridSizeX, gridSizeY;

    //Number of rooms allowed to be created
    public int numberOfRooms;

    RoomTemplates _RoomTemplates;

    private void Start()
    {
        _RoomTemplates = GetComponent<RoomTemplates>();
        CreateFloor();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetFloor();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            ClearFloor();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            CreateFloor();
        }
    }

    public void CreateFloor()
    {
        //Creates an array of Rooms for current floor
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];

        //Sets spawning room in the mid of the grid
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 0);
        takenPositions.Add(Vector2.zero);

        RandomRoomPlacement();
    }

    private void ClearFloor()
    {
        takenPositions.Clear();
        for (int i = 0; i < rooms.GetLength(0); i++)
        {
            for (int e = 0; e < rooms.GetLength(1); e++)
            {
                if(rooms[i, e] != null)
                {
                    rooms[i, e].type = null;
                    rooms[i, e].doorValue = null;
                    rooms[i, e].doorTop = null;
                    rooms[i, e].doorRight = null;
                    rooms[i, e].doorBottom = null;
                    rooms[i, e].doorRight = null;
                    rooms[i, e].gridPos = Vector2.zero;
                    Destroy(rooms[i, e].sprite);
                    rooms[i, e].sprite = null;
                    Destroy(rooms[i, e].typeSprite);
                    rooms[i, e].typeSprite = null;
                }
            }
        }
    }

    public void ResetFloor()
    {
        ClearFloor();
        new WaitForEndOfFrame();
        CreateFloor();
    }

    private void RandomRoomPlacement()
    {
        int randomDirection;
        bool roomPlaced;
        Vector2 takenPosition;
        Vector2 newPosition;

        for (int i = 0; i < numberOfRooms; i++)
        {
            roomPlaced = false;
            while (roomPlaced == false)
            {
                randomDirection = Random.Range(0, 4);
                takenPosition = takenPositions[Random.Range(0, takenPositions.Count)];
                if(Random.Range(0, numberOfRooms/2) == 0)
                {
                    int loops = 0;
                    do
                    {
                        loops++;
                        takenPosition = takenPositions[Random.Range(0, takenPositions.Count)];
                        if(loops == 50)
                        {
                            break;
                        }
                    } while (CheckNeighbors(rooms[(int)takenPosition.x + gridSizeX, (int)takenPosition.y + gridSizeY]) != 1);
                }
                switch (randomDirection)
                {
                    case 0: //Up
                        newPosition = new Vector2(takenPosition.x, takenPosition.y + 1);
                        break;
                    case 1: //Right
                        newPosition = new Vector2(takenPosition.x + 1, takenPosition.y);
                        break;
                    case 2: //Bottom
                        newPosition = new Vector2(takenPosition.x, takenPosition.y - 1);
                        break;
                    case 3: //Left
                        newPosition = new Vector2(takenPosition.x - 1, takenPosition.y);
                        break;
                    default: //Defaults to up
                        newPosition = new Vector2(takenPosition.x, takenPosition.y + 1);
                        break;
                }

                //Check if newPosition is out of the grid
                if (Mathf.Abs(newPosition.x) <= gridSizeX && Mathf.Abs(newPosition.y) <= gridSizeY)
                {
                    if (rooms[(int)newPosition.x + gridSizeX, (int)newPosition.y + gridSizeY] == null)
                    {
                        rooms[(int)newPosition.x + gridSizeX, (int)newPosition.y + gridSizeY] = new Room(newPosition, 0);
                        takenPositions.Add(newPosition);
                        roomPlaced = true;
                    }
                }
            }
        }
        ConnectRooms();
    }

    private int CheckNeighbors(Room room)
    {
        int numberOfNeighbors = 0;
        if (room != null && room.type != null)
        {
            room.doorValue = 0;
            try
            {
                if (rooms[(int)room.gridPos.x + gridSizeX, (int)room.gridPos.y + gridSizeY + 1] != null)
                    numberOfNeighbors++;
            }
            catch { };
            try
            {
                if (rooms[(int)room.gridPos.x + gridSizeX, (int)room.gridPos.y + gridSizeY - 1] != null)
                    numberOfNeighbors++;
            }
            catch { };
            try
            {
                if (rooms[(int)room.gridPos.x + gridSizeX + 1, (int)room.gridPos.y + gridSizeY] != null)
                    numberOfNeighbors++;
            }
            catch { };
            try
            {
                if (rooms[(int)room.gridPos.x + gridSizeX - 1, (int)room.gridPos.y + gridSizeY] != null)
                    numberOfNeighbors++;
            }
            catch { };
        }
        return numberOfNeighbors;
    }

    private void ConnectRooms()
    {
        for (int i = 0; i < rooms.GetLength(0); i++)
        {
            for (int e = 0; e < rooms.GetLength(1); e++)
            {
                if (rooms[i, e] != null && rooms[i, e].type != null)
                {
                    rooms[i, e].doorValue = 0;
                    try
                    {
                        if (rooms[(int)rooms[i, e].gridPos.x + gridSizeX, (int)rooms[i, e].gridPos.y + gridSizeY + 1] != null)
                        {
                            rooms[i, e].doorValue += 1;
                        }
                    }
                    catch
                    {
                        Debug.Log(rooms[i, e].gridPos + "<color=green> has no neighbor to the top</color>");
                    }

                    try
                    {
                        if (rooms[(int)rooms[i, e].gridPos.x + gridSizeX + 1, (int)rooms[i, e].gridPos.y + gridSizeY] != null)
                        {
                            rooms[i, e].doorValue += 2;
                        }
                    }
                    catch
                    {
                        Debug.Log(rooms[i, e].gridPos + "<color=red> has no neighbor to the right</color>");
                    }

                    try
                    {
                        if (rooms[(int)rooms[i, e].gridPos.x + gridSizeX - 1, (int)rooms[i, e].gridPos.y + gridSizeY] != null)
                        {
                            rooms[i, e].doorValue += 8;
                        }
                    }
                    catch
                    {
                        Debug.Log(rooms[i, e].gridPos + "<color=yellow> has no neighbor to the left</color>");
                    }

                    try
                    {
                        if (rooms[(int)rooms[i, e].gridPos.x + gridSizeX, (int)rooms[i, e].gridPos.y + gridSizeY - 1] != null)
                        {
                            rooms[i, e].doorValue += 4;
                        }
                    }
                    catch
                    {
                        Debug.Log(rooms[i, e].gridPos + "<color=blue> has no neighbor to the bottom</color>");
                    }
                }
            }
        }
        GiveRoomsType();
    }

    private void GiveRoomsType()
    {
        bool lootRoomSpawned = false;
        bool bossRoomSpawned = false;
        List<Room> viableRooms = new List<Room>();

        for (int i = 0; i < rooms.GetLength(0); i++)
        {
            for (int e = 0; e < rooms.GetLength(1); e++)
            {
                if (rooms[i, e] != null && rooms[i, e].doorValue != null)
                {
                    if (rooms[i, e].doorValue == 1 || rooms[i, e].doorValue == 2 || rooms[i, e].doorValue == 4 || rooms[i, e].doorValue == 8)
                    {
                        viableRooms.Add(rooms[i, e]);
                    }
                }
            }
        }

        if(viableRooms.Count <= 1)
        {
            ResetFloor();
            return;
        }

        while (lootRoomSpawned == false || bossRoomSpawned == false)
        {
            Room room = viableRooms[Random.Range(0, viableRooms.Count)];

            if (lootRoomSpawned == false && room.type == 0)
            {
                rooms[(int)room.gridPos.x + gridSizeX, (int)room.gridPos.y + gridSizeY].type = 1;
                lootRoomSpawned = true;
            }

            else if (bossRoomSpawned == false && room.type == 0)
            {
                rooms[(int)room.gridPos.x + gridSizeX, (int)room.gridPos.y + gridSizeY].type = 2;
                bossRoomSpawned = true;
            }
        }
        VisualizeRooms();
    }

    private void VisualizeRooms()
    {
        for (int i = 0; i < rooms.GetLength(0); i++)
        {
            for(int e = 0; e < rooms.GetLength(1); e++)
            {
                if (rooms[i, e] != null)
                {
                    if (rooms[i, e].type != null)
                    {
                        switch (rooms[i, e].doorValue)
                        {
                            case 0:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsBlank[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 1:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsT[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 2:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsR[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 3:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsTR[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 4:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsB[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 5:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsTB[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 6:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsRB[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 7:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsTRB[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 8:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 9:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsTL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 10:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsRL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 11:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsTRL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 12:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsBL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 13:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsTBL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 14:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsRBL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            case 15:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsTRBL[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                            default:
                                rooms[i, e].sprite = Instantiate(_RoomTemplates.roomsBlank[Random.Range(0, _RoomTemplates.roomsT.Length)], new Vector3(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                                break;
                        }
                        rooms[i, e].typeSprite = Instantiate(_RoomTemplates.roomTypeIcons[(int)rooms[i, e].type], new Vector2(rooms[i, e].gridPos.x * 20, rooms[i, e].gridPos.y * 15), Quaternion.identity);
                    }
                }
            }
        }
    }
}
