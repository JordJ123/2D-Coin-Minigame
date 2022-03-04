using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy 
{
    [RequireComponent(typeof(MovementController))]
    public class TriggerDetector : MonoBehaviour
    {
        private MovementController movementController;
        private bool detect;
        private BoxCollider2D colliderBounds;
        private float leftX;
        private float rightX;
        private float topY;
        private float bottomY;
        private IntersectionController intersectionController;

        private void Awake()
        {
            movementController = GetComponent<MovementController>();
            colliderBounds = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerStay2D(Collider2D collider) 
        {
            if (collider.tag == "Intersection" && detect)
            {
                leftX = colliderBounds.bounds.center.x 
					- colliderBounds.bounds.extents.x;
                rightX = colliderBounds.bounds.center.x 
					+ colliderBounds.bounds.extents.x;
                topY = colliderBounds.bounds.center.y 
					+ colliderBounds.bounds.extents.y;
                bottomY = colliderBounds.bounds.center.y 
					- colliderBounds.bounds.extents.y;
                intersectionController 
					= collider.GetComponent<IntersectionController>();
                if (leftX >= intersectionController.GetLeftX() 
                    && rightX <= intersectionController.GetRightX() 
                    && topY <= intersectionController.GetTopY() 
                    & bottomY >= intersectionController.GetBottomY())
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

