using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Player 
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(InputController))]
	[RequireComponent(typeof(PowerUpController))]
	[RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteController))]
	[RequireComponent(typeof(Transform))]
	public class MovementController : MonoBehaviour
	{
		[SerializeField] public UnityEvent OnMove;
		[SerializeField] public UnityEvent<Transform> OnMoveDistance;
		[SerializeField] public UnityEvent OnMoveSpeed;
		[SerializeField] public UnityEvent<bool, Transform> OnMoveSpeedDistance;
		[SerializeField] public UnityEvent<string, bool> OnMoveAnimation;
		[SerializeField] public UnityEvent<AudioClip, float> OnMoveSound;
		[SerializeField] public AudioClip movementSound;
        [SerializeField] private float moveDistance;
		[SerializeField] private float soundVolume;
		[SerializeField] private float soundDelay;

		private Animator animator;
		private InputController inputController;
		private PowerUpController powerUpController;
		private Rigidbody2D rb2D;
		private SpriteController spriteController;
		private Transform tf;
		private float horizontalSpeed;
		private float verticalSpeed;
		private bool isCoroutine;
		private bool lookingRight;
		private Vector2 previousVelocity;
		private Vector2 velocity;

        private void Awake()
		{
			animator = GetComponent<Animator>();
			inputController = GetComponent<InputController>();
			powerUpController = GetComponent<PowerUpController>();
			tf = transform;
			rb2D = GetComponent<Rigidbody2D>();
            spriteController = GetComponent<SpriteController>();
			previousVelocity = new Vector2();
			velocity = new Vector2();
			lookingRight = spriteController.IsLookingRight();
		}

		private void Start()
		{
			OnMoveAnimation.AddListener(animator.SetBool);
		}

		public void SetNormalSound()
		{
			soundDelay *= 2;
		}

		public void SetSpeedSound()
		{
			soundDelay /= 2;
		}

		void FixedUpdate()
        {
            Move();
        }

        private void Move()
		{
			velocity.x = MoveHorizontal();
			velocity.y = MoveVertical();
			rb2D.velocity = velocity;
			if (velocity.x != 0 || velocity.y != 0)
			{
				if (previousVelocity.x == 0 && previousVelocity.y == 0)
				{
					OnMoveAnimation?.Invoke("Moving", true);
				}
				if (!isCoroutine)
				{
					isCoroutine = true;
					StartCoroutine(MovementSound());
				}
				OnMove?.Invoke();
				OnMoveDistance?.Invoke(tf);
				if (powerUpController.HasSpeedPowerUp())
				{
					OnMoveSpeed?.Invoke();
				}
				OnMoveSpeedDistance?
					.Invoke(powerUpController.HasSpeedPowerUp(), tf);
			}
			else
			{
				if (previousVelocity.x != 0 || previousVelocity.y != 0)
				{
					OnMoveAnimation?.Invoke("Moving", false);
				}
				isCoroutine = false;
				StopAllCoroutines();
			}
			previousVelocity = velocity;
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

		protected IEnumerator MovementSound()
		{
			while (true)
			{
				OnMoveSound?.Invoke(movementSound, soundVolume);
				yield return new WaitForSeconds(soundDelay);
			}
		}
    }
}
