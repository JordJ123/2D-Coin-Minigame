using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField] private Direction direction;
	private DirectionType directionType;
    private MovementController movementController;
    private bool hasWall;

	private void Awake()
	{
		directionType = transform.parent.GetComponent<DirectionType>();
		movementController = transform.parent
			.GetComponent<MovementController>();
    }

    public Direction GetDirection()
    {
        return direction;
    }

    public bool HasWall()
    {
        return hasWall;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Maze")
        {
			hasWall = true;
			if (directionType.Direction == direction)
			{
				movementController.SetWallDirection();
			}
		}
    }
    
    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.tag == "Maze")
        {
            hasWall = false;
        }
    }
}
