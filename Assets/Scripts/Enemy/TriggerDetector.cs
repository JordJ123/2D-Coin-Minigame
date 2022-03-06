using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy 
{
	[RequireComponent(typeof(DirectionType))]
	[RequireComponent(typeof(MovementController))]
    public class TriggerDetector : MonoBehaviour
    {
		private DirectionType directionType;
		private MovementController movementController;
		private bool detect = true;
        private BoxCollider2D colliderBounds;
        private float leftX;
        private float rightX;
        private float topY;
        private float bottomY;
        private Direction intersectionDirection;
        private IntersectionController intersectionController;
		private bool inBounds;

        private void Awake()
		{
			directionType = GetComponent<DirectionType>();
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
                intersectionDirection 
					= collider.GetComponent<DirectionType>().Direction;
				intersectionController 
					= collider.GetComponent<IntersectionController>();
				inBounds = false;
				switch (intersectionDirection)
				{
					case Direction.LEFT:
					case Direction.RIGHT:
						inBounds = topY <= intersectionController.GetTopY()
							&& bottomY >= intersectionController.GetBottomY()
							&& directionType.Direction != Direction.LEFT
							&& directionType.Direction != Direction.RIGHT;
						break;
					case Direction.UP:
					case Direction.DOWN:
						inBounds = leftX >= intersectionController.GetLeftX() 
							&& rightX <= intersectionController.GetRightX()
							&& directionType.Direction != Direction.UP
							&& directionType.Direction != Direction.DOWN;
						break;
				}
				if (inBounds)
				{
					detect = false;
					Debug.Log("Intersection");
					movementController
						.SetIntersectionDirection(intersectionDirection);
				}
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
			if (collider.tag == "Intersection")
			{
				detect = true;
			}
		}
    }
}

