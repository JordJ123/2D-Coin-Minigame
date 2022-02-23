using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public enum Direction
    {
        RIGHT,
        LEFT,
        UP,
        DOWN
    }
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
        [SerializeField] private Direction direction;
        private Rigidbody2D rigidbody2D;
        private SpriteController spriteController;
        private Vector2 velocity;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteController = GetComponent<SpriteController>();
        }

        public void SetDirection()
        {
            velocity = rigidbody2D.velocity;
            switch (direction)
            {
                case Direction.RIGHT:
                    velocity.x = 0;
                    direction = Direction.DOWN;
                    break;
                case Direction.LEFT:
                    velocity.x = 0;
                    direction = Direction.UP;
                    break;
                case Direction.UP:
                    velocity.y = 0;
                    direction = Direction.RIGHT;
                    spriteController.FlipRight();
                    break;
                case Direction.DOWN:
                    velocity.y = 0;
                    direction = Direction.LEFT;
                    spriteController.FlipLeft();
                    break;
            }
            rigidbody2D.velocity = velocity;
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
    
