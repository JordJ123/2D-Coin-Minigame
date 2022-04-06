using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Player 
{
	[RequireComponent(typeof(InputController))]
	[RequireComponent(typeof(PowerUpController))]
	[RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteController))]
	public class MovementController : MonoBehaviour
	{
		[SerializeField] public UnityEvent<bool, Transform> OnMove;
        [SerializeField] private float moveDistance;
		
		private InputController inputController;
		private PowerUpController powerUpController;
		private Transform tf;
        private Rigidbody2D rb2D;
        private SpriteController spriteController;
		private float horizontalSpeed;
		private float verticalSpeed;
		private bool lookingRight;
        private Vector2 velocity;

        private void Awake()
		{
			inputController = GetComponent<InputController>();
			powerUpController = GetComponent<PowerUpController>();
			tf = transform;
			rb2D = GetComponent<Rigidbody2D>();
            spriteController = GetComponent<SpriteController>();
			velocity = new Vector2();
			lookingRight = spriteController.IsLookingRight();
		}

		void Update()
        {
            Move();
        }

        private void Move()
        {
            velocity = rb2D.velocity;
            velocity.x = MoveHorizontal();
            velocity.y = MoveVertical();
            rb2D.velocity = velocity;
			if (velocity.x != 0 || velocity.y != 0)
			{
				OnMove?.Invoke(powerUpController.HasSpeedPowerUp(), tf);
			}
        }

        private float MoveHorizontal()
        {
            
            horizontalSpeed = inputController.GetHorizontalAxis()
				* moveDistance;
			if (horizontalSpeed < 0 && lookingRight)
            {
                lookingRight = false;
                spriteController.FlipLeft();
            } 
            else if (horizontalSpeed > 0 && !lookingRight)
            {
                lookingRight = true;
                spriteController.FlipRight();
            }
			if (powerUpController.HasSpeedPowerUp())
			{
				return horizontalSpeed * 2;
			}
			return horizontalSpeed;
		}
        
        private float MoveVertical()
		{
			verticalSpeed = inputController.GetVerticalAxis() * moveDistance;
			if (powerUpController.HasSpeedPowerUp())
			{
				return verticalSpeed * 2;
			}
            return verticalSpeed;
        }
    }
}
