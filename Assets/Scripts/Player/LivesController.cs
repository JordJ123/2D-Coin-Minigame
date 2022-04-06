using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
	public class LivesController : MonoBehaviour
	{
		[SerializeField] public UnityEvent<int> OnGain;
		[SerializeField] private UnityEvent<int> OnStart;
		[SerializeField] private UnityEvent<int> OnLose;
		[SerializeField] private UnityEvent OnGameOver;
		[SerializeField] private int lives;
		private GameObject gameObj;
		private PowerUpController powerUpController;
		private bool isDead;
		private bool isGameOver;

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
			OnGain?.Invoke(lives);
		}
    
		public bool LoseLife()
		{
			lives--;
			if (lives == 0)
			{
				isDead = EndGame();
			}
			OnLose?.Invoke(lives);
			return isDead;
		}

		private bool EndGame()
		{
			isGameOver = true;
			foreach (var livesController 
				in FindObjectsOfType<LivesController>(true))
			{
				if (livesController.lives != 0)
				{
					isGameOver = false;
					break;
				}
			}
			if (isGameOver)
			{
				OnGameOver?.Invoke();
			}
			else
			{
				powerUpController.RemovePowerUp();
				gameObj.SetActive(false);
				return true;
			}
			return false;
		}
	}
}