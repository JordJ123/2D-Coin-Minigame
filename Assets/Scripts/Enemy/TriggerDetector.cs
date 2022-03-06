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
		private BoxCollider2D boxCollider2D;
		private DirectionType directionType;
		private MovementController movementController;
		private bool hasChecked = true;
        private float leftX;
        private float rightX;
        private float topY;
        private float bottomY;
        private Direction intersectionDirection;
        private IntersectionController intersectionController;
		private bool inBounds;

        private void Awake()
		{
			boxCollider2D = GetComponent<BoxCollider2D>();
			directionType = GetComponent<DirectionType>();
			movementController = GetComponent<MovementController>();
		}

        private void OnTriggerStay2D(Collider2D collider) 
        {
            if (collider.tag == "Intersection" && hasChecked)
            {
				intersectionDirection 
					= collider.GetComponent<DirectionType>().Direction;
				intersectionController 
					= collider.GetComponent<IntersectionController>();
				inBounds = false;
				switch (intersectionDirection)
				{
					case Direction.LEFT:
					case Direction.RIGHT:
						topY = boxCollider2D.bounds.center.y 
							+ boxCollider2D.bounds.extents.y;
						bottomY = boxCollider2D.bounds.center.y 
							- boxCollider2D.bounds.extents.y;
						inBounds = topY <= intersectionController.GetTopY()
							&& bottomY >= intersectionController.GetBottomY()
							&& directionType.Direction != Direction.LEFT
							&& directionType.Direction != Direction.RIGHT;
						break;
					case Direction.UP:
					case Direction.DOWN:
						leftX = boxCollider2D.bounds.center.x 
							- boxCollider2D.bounds.extents.x;
						rightX = boxCollider2D.bounds.center.x 
							+ boxCollider2D.bounds.extents.x;
						inBounds = leftX >= intersectionController.GetLeftX() 
							&& rightX <= intersectionController.GetRightX()
							&& directionType.Direction != Direction.UP
							&& directionType.Direction != Direction.DOWN;
						break;
				}
				if (inBounds)
				{
					hasChecked = false;
					movementController
						.SetIntersectionDirection(intersectionDirection);
				}
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
			if (collider.tag == "Intersection")
			{
				hasChecked = true;
			}
		}
    }
}

