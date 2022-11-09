using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
	#nullable enable
	public Vector2 gridPos;
	public int? type;
	public int? doorValue;
	public GameObject? walls;
	public GameObject? floor;
<<<<<<< Updated upstream
	public GameObject? doors;
=======
	public GameObject? topDoor;
	public GameObject? rightDoor;
	public GameObject? bottomDoor;
	public GameObject? leftDoor;
>>>>>>> Stashed changes
	public GameObject? typeSprite;

	public Room(Vector2 _gridPos, int _type)
	{
		gridPos = _gridPos;
		type = _type;
	}
}
