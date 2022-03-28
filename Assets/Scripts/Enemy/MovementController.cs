using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
	[RequireComponent(typeof(DirectionType))]
	[RequireComponent(typeof(HealthController))]
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(SpriteController))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
		
		private DirectionType directionType;
		private HealthController healthController;
		private Rigidbody2D rb2D;
        private SpriteController spriteController;
        private WallDetector[] wallDetectors = new WallDetector[4];

		private List<Direction> availableDirections = new List<Direction>();
		private Direction reverseDirection;
		private Vector2 velocity;
		private bool canMove = true;
		private Direction startingDirection;

        private void Awake()
		{
			directionType = GetComponent<DirectionType>();
			healthController = GetComponent<HealthController>();
			rb2D = GetComponent<Rigidbody2D>();
            spriteController = GetComponent<SpriteController>();
            for (int i = 0; i < 4; i++)
            {
                wallDetectors[i] = transform.GetChild(i)
					.gameObject.GetComponent<WallDetector>();
            }
			reverseDirection = SetReverseDirection();
			startingDirection = directionType.Direction;
		}

		private void Start()
		{
			healthController.OnDeath += FreezeMovement;
			healthController.OnRevive += UnfreezeMovement;
			healthController.OnReset += ResetMovement;
		}
		
		private void OnDisable()
		{
			healthController.OnDeath -= FreezeMovement;
			healthController.OnRevive -= UnfreezeMovement;
			healthController.OnReset -= ResetMovement;
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
                    spriteController.FlipRight();
                    break;
                case Direction.LEFT:
                    spriteController.FlipLeft();
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
				velocity = rb2D.velocity;
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

		private void ResetMovement()
		{
			ResetVelocity();
			directionType.Direction = startingDirection;
			reverseDirection = SetReverseDirection();
			canMove = true;
		}
		
		private void FreezeMovement()
		{
			ResetMovement();
			canMove = false;
		}

		private void UnfreezeMovement()
		{
			canMove = true;
		}

		private void ResetVelocity()
		{
			velocity = rb2D.velocity;
			velocity.x = 0;
			velocity.y = 0;
			rb2D.velocity = velocity;
		}
	}
}
    
