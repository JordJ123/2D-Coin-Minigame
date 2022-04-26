using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy 
{
	[RequireComponent(typeof(BoxCollider2D))]
	[RequireComponent(typeof(DirectionType))]
	[RequireComponent(typeof(MovementController))]
    public class TriggerDetector : MonoBehaviour
    {
		[SerializeField] public UnityEvent<Direction> OnIntersection;
		private BoxCollider2D boxCollider2D;
		private DirectionType directionType;
		private bool isValid = true;
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
		}

        private void OnTriggerStay2D(Collider2D collider) 
        {
            if (collider.tag == "Intersection" && isValid)
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
						if (directionType.Direction == Direction.UP
							|| directionType.Direction == Direction.DOWN)
						{
							topY = boxCollider2D.bounds.center.y 
								+ boxCollider2D.bounds.extents.y;
							bottomY = boxCollider2D.bounds.center.y 
								- boxCollider2D.bounds.extents.y;
							inBounds = topY <= intersectionController.GetTopY() 
								&& bottomY 
									>= intersectionController.GetBottomY();
						}
						else
						{
							isValid = false;
						}
						break;
					case Direction.UP:
					case Direction.DOWN:
						if (directionType.Direction == Direction.LEFT
							|| directionType.Direction == Direction.RIGHT)
						{
							leftX = boxCollider2D.bounds.center.x 
								- boxCollider2D.bounds.extents.x;
							rightX = boxCollider2D.bounds.center.x 
								+ boxCollider2D.bounds.extents.x;
							inBounds
								= leftX >= intersectionController.GetLeftX()
								&& rightX <= intersectionController.GetRightX();
						}
						else
						{
							isValid = false;
						}
						break;
				}
				if (inBounds)
				{
					isValid = false;
					OnIntersection?.Invoke(intersectionDirection);
				}
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
			if (collider.tag == "Intersection")
			{
				isValid = true;
			}
		}
    }
}

