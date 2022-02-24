using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField] private Direction direction;
    private MovementController movementController;
    private bool hasWall;
    
    private void Awake()
    {
        movementController = transform.parent.gameObject.GetComponent<MovementController>();
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
            movementController.SetDirection();
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
