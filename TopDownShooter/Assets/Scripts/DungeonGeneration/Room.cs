using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
	#nullable enable
	public Vector2 gridPos;
	public int? type;
	public bool? doorTop, doorBottom, doorLeft, doorRight;
	public int? doorValue;
	public GameObject? sprite;
	public GameObject? typeSprite;

	public Room(Vector2 _gridPos, int _type)
	{
		gridPos = _gridPos;
		type = _type;
	}
}
