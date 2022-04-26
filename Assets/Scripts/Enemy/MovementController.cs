using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Enemy
{
	[RequireComponent(typeof(DirectionType))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovementController : MonoBehaviour
	{
		[SerializeField] private UnityEvent<bool> OnFlipRight;
		[SerializeField] private float moveDistance;
		private DirectionType directionType;
		private Rigidbody2D rb2D;
		private WallDetector[] wallDetectors = new WallDetector[4];
		private List<Direction> availableDirections = new List<Direction>();
		private Direction reverseDirection;
		private Vector2 velocity;
		private bool canMove = true;
		private Direction startingDirection;

        private void Awake()
		{
			directionType = GetComponent<DirectionType>();
			rb2D = GetComponent<Rigidbody2D>();
            for (int i = 0; i < 4; i++)
            {
                wallDetectors[i] = transform.GetChild(i)
					.gameObject.GetComponent<WallDetector>();
            }
			reverseDirection = SetReverseDirection();
			startingDirection = directionType.Direction;
		}

		private Direction SetReverseDirection()
		{
			switch (directionType.Direction)
			{
				case Direction.RIGHT:
					return Direction.LEFT;
				case Direction.LEFT:
					return Direction.RIGHT;
				case Direction.UP:
					return Direction.DOWN;
				case Direction.DOWN:
					return Direction.UP;
			}
			throw new InvalidEnumArgumentException();
		}

		public void SetIntersectionDirection(Direction intersectionDirection)
		{
			ResetVelocity();
            availableDirections.Clear();
            availableDirections.Add(directionType.Direction);
            availableDirections.Add(intersectionDirection);
            directionType.Direction = availableDirections[Random.Range(0, 2)];
			reverseDirection = SetReverseDirection();
            SetSpriteDirection();
        }

        public void SetWallDirection()
		{
			ResetVelocity();
            availableDirections.Clear();
            foreach (var wallDetector in wallDetectors)
            {
                if (!wallDetector.HasWall() 
					&& wallDetector.GetDirection() != reverseDirection)
                {
                    availableDirections.Add(wallDetector.GetDirection());   
                }
            }
            directionType.Direction = availableDirections[
				Random.Range(0, availableDirections.Count)];
			reverseDirection = SetReverseDirection();
			SetSpriteDirection();
        }

        private void SetSpriteDirection()
        {
            switch (directionType.Direction)
            {
                case Direction.RIGHT:
					OnFlipRight?.Invoke(true);
					break;
                case Direction.LEFT:
					OnFlipRight?.Invoke(false);
					break;
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
			if (canMove)
			{
				switch (directionType.Direction)
				{
					case Direction.RIGHT:
						velocity.x = moveDistance;
						break;
					case Direction.LEFT:
						velocity.x = -moveDistance;
						break;
					case Direction.UP:
						velocity.y = moveDistance;
						break;
					case Direction.DOWN:
						velocity.y = -moveDistance;
						break;
				}
				rb2D.velocity = velocity;
			}
			else
			{
				ResetVelocity();
			}
		}

		public void ResetMovement()
		{
			ResetVelocity();
			directionType.Direction = startingDirection;
			reverseDirection = SetReverseDirection();
			canMove = true;
		}
		
		public void FreezeMovement()
		{
			ResetMovement();
			canMove = false;
		}

		public void UnfreezeMovement()
		{
			canMove = true;
		}

		private void ResetVelocity()
		{
			velocity.x = 0;
			velocity.y = 0;
			rb2D.velocity = velocity;
		}
	}
}
    
