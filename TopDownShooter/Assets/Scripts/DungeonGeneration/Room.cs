using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
	#nullable enable
	public Vector2 gridPos;
	public bool? isRoomCompleted;
	public int? type;
	public int? doorValue;
	public GameObject? walls;
	public GameObject? floor;
	public GameObject? obstacles;
	public GameObject? topDoor;
	public GameObject? rightDoor;
	public GameObject? bottomDoor;
	public GameObject? leftDoor;

	public Room(Vector2 _gridPos, int _type)
	{
		gridPos = _gridPos;
		type = _type;
	}
}
