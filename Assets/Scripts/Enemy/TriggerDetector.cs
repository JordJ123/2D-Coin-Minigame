using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(MovementController))]
    public class TriggerDetector : MonoBehaviour
    {
        private MovementController movementController;
        private bool detect;
        private BoxCollider2D enemyBounds;
        private float enemyLeftX;
        private float enemyRightX;
        private float enemyTopY;
        private float enemyBottomY;
        private IntersectionController intersectionController;

        private void Awake()
        {
            movementController = GetComponent<MovementController>();
            enemyBounds = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerStay2D(Collider2D collider) 
        {
            if (collider.tag == "Intersection" && detect)
            {
                enemyLeftX = enemyBounds.bounds.center.x - enemyBounds.bounds.extents.x;
                enemyRightX = enemyBounds.bounds.center.x + enemyBounds.bounds.extents.x;
                enemyTopY = enemyBounds.bounds.center.y + enemyBounds.bounds.extents.y;
                enemyBottomY = enemyBounds.bounds.center.y - enemyBounds.bounds.extents.y;
                intersectionController = collider.GetComponent<IntersectionController>();
                if (enemyLeftX >= intersectionController.GetIntersectionLeftX()
                    && enemyRightX <= intersectionController.GetIntersectionRightX() 
                    && enemyTopY <= intersectionController.GetIntersectionTopY() 
                    && enemyBottomY >= intersectionController.GetIntersectionBottomY())
                {
                    detect = false;
                    movementController.SetIntersectionDirection(
                        collider.GetComponent<DirectionType>().Direction);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            detect = true;
        }
    }
}

