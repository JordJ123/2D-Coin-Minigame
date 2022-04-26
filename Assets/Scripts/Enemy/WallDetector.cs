using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.Events;

public class WallDetector : MonoBehaviour
{
	[SerializeField] public UnityEvent OnWall;
    [SerializeField] private Direction direction;
	private DirectionType directionType;
	private bool hasWall;

	private void Awake()
	{
		directionType = transform.parent.GetComponent<DirectionType>();
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
				OnWall?.Invoke();
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
