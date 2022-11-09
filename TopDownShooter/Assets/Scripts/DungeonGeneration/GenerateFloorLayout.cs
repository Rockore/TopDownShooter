using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloorLayout : MonoBehaviour
{
<<<<<<< Updated upstream
    private Room[,] rooms { get; set; }
    private List<Vector2> takenPositions = new List<Vector2>();
    public int gridSizeX, gridSizeY;
=======
    public static Room[,] rooms { get; set; }
    private List<Vector2> takenPositions = new List<Vector2>();
    public static int gridSizeX, gridSizeY;
>>>>>>> Stashed changes
    public int numberOfRooms;
    private RoomTemplates _RoomTemplates;
    private CreateRooms _CreateRooms;

    private void Start()
    {
        gridSizeX = 10;
        gridSizeY = 10;
        _RoomTemplates = GetComponent<RoomTemplates>();
        _CreateRooms = GetComponent<CreateRooms>();
        Debug.Log("Start");
        CreateFloorLayout();
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
            CreateFloorLayout();
        }
    }

    public void ResetFloor()
    {
        ClearFloor();
        new WaitForEndOfFrame();
        CreateFloorLayout();
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
                    rooms[i, e].floor = null;
                    rooms[i, e].walls = null;
                    rooms[i, e].doors = null;
                    rooms[i, e].doorValue = null;
                    rooms[i, e].gridPos = Vector2.zero;
                    Destroy(rooms[i, e].typeSprite);
                    rooms[i, e].typeSprite = null;
                }
            }
        }
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

    private void CreateFloorLayout()
    {
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 0);
        takenPositions.Add(Vector2.zero);
        Debug.Log("Created Floor Layout");
        RandomRoomPlacement();
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
        Debug.Log("Random Placed Rooms");
        GiveDoorValue();
    }

    private void GiveDoorValue()
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
        Debug.Log("Gave Rooms values");
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
        Debug.Log("Gave Rooms types");
        AssignRooms();
    }

    private void AssignRooms()
    {
        for (int i = 0; i < rooms.GetLength(0); i++)
        {
            for (int e = 0; e < rooms.GetLength(1); e++)
            {
                if (rooms[i, e] != null && rooms[i, e].doorValue != null)
                {
                    Debug.Log(rooms[i, e].floor);
                    rooms[i, e] = _CreateRooms.CreateRoom(rooms[i, e]);
                }
            }
        }
        Debug.Log("Assigned Rooms");
    }

    public Room[,] Rooms { get; set; }
}
