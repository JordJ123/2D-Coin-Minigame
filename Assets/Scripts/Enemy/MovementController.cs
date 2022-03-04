using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
        [SerializeField] private Direction direction;
        
        private Rigidbody2D rigidbody2D;
        private SpriteController spriteController;
        private WallDetector[] wallDetectors = new WallDetector[4];
            
        private List<Direction> availableDirections = new List<Direction>();
        private Vector2 velocity;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteController = GetComponent<SpriteController>();
            for (int i = 0; i < 4; i++)
            {
                wallDetectors[i] = transform.GetChild(i + 1).gameObject.GetComponent<WallDetector>();
            }
        }

        public void SetIntersectionDirection(Direction intersectionDirection)
        {
            velocity = rigidbody2D.velocity;
            velocity.x = 0;
            velocity.y = 0;
            rigidbody2D.velocity = velocity;
            availableDirections.Clear();
            availableDirections.Add(direction);
            availableDirections.Add(intersectionDirection);
            direction = availableDirections[Random.Range(0, 2)];
            SetSpriteDirection();
        }

        public void SetWallDirection()
        {
            velocity = rigidbody2D.velocity;
            velocity.x = 0;
            velocity.y = 0;
            rigidbody2D.velocity = velocity;
            availableDirections.Clear();
            foreach (var wallDetector in wallDetectors)
            {
                if (!wallDetector.HasWall())
                {
                    availableDirections.Add(wallDetector.GetDirection());   
                }
            }
            direction = availableDirections[Random.Range(0, availableDirections.Count)];
            SetSpriteDirection();
        }

        private void SetSpriteDirection()
        {
            switch (direction)
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
            velocity = rigidbody2D.velocity;
            switch (direction)
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
            rigidbody2D.velocity = velocity;
        }
    }
}
    
