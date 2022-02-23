using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private MovementController movementController;
    
    private void Awake()
    {
        movementController = transform.parent.gameObject.GetComponent<MovementController>();
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Maze")
        {
            movementController.SetDirection();
        }
    }
}
