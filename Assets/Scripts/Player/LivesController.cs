using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Player
{
	public class LivesController : MonoBehaviour
	{
		[SerializeField] private UnityEvent<int> OnStart;
		[SerializeField] private UnityEvent<int> OnGain;
		[SerializeField] private UnityEvent<int> OnLose;
		[SerializeField] private int lives;
		private static LivesController[] livesControllers;
		private GameObject gameObj;
		private PowerUpController powerUpController;
		private bool isDead;
		private bool isGameOver;

		public static event Action<int> OnStaticGain;

		private void Awake()
		{
			gameObj = gameObject;
			powerUpController = GetComponent<PowerUpController>();
		}

		private void Start()
		{
			OnStart?.Invoke(lives);
		}

		public void GainLife()
		{
			lives++;
			OnStaticGain?.Invoke(lives);
			OnGain?.Invoke(lives);
		}
    
		public bool LoseLife()
		{
			lives--;
			if (lives == 0)
			{
				isDead = Die();
			}
			OnLose?.Invoke(lives);
			return isDead;
		}

		private bool Die()
		{
			isGameOver = true;
			if (livesControllers == null)
			{
				livesControllers = FindObjectsOfType<LivesController>(false);
			}
			foreach (var livesController in livesControllers)
			{
				if (livesController.lives != 0)
				{
					isGameOver = false;
					break;
				}
			}
			if (isGameOver)
			{
				SceneManager.LoadScene("DeathScreen");
			}
			else
			{
				powerUpController.RemovePowerUp();
				Destroy(gameObj);
				return true;
			}
			return false;
		}
	}
}