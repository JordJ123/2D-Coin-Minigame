using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    RIGHT,
    LEFT,
    UP,
    DOWN
}

public class DirectionType : MonoBehaviour
{
    [SerializeField] private Direction direction;

    public Direction Direction
	{
		set => direction = value;
		get => direction;
	}
}
