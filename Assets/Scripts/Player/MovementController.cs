using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Player 
{
	[RequireComponent(typeof(PowerUpController))]
	[RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteController))]
	public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
		
		public static event Action<bool> OnMove;
		private PowerUpController powerUpController;
        private Rigidbody2D rb2D;
        private SpriteController spriteController;
		private float horizontalSpeed;
		private float verticalSpeed;
		private bool lookingRight = true;
        private Vector2 velocity;

        private void Awake()
		{
			powerUpController = GetComponent<PowerUpController>();
			rb2D = GetComponent<Rigidbody2D>();
            spriteController = GetComponent<SpriteController>();
            velocity = new Vector2();
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
				OnMove?.Invoke(powerUpController.HasSpeedPowerUp());
			}
        }

        private float MoveHorizontal()
        {
            
            horizontalSpeed = Input.GetAxis("Horizontal") * moveDistance;
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
			verticalSpeed = Input.GetAxis("Vertical") * moveDistance;
			if (powerUpController.HasSpeedPowerUp())
			{
				return verticalSpeed * 2;
			}
            return verticalSpeed;
        }
    }
}
