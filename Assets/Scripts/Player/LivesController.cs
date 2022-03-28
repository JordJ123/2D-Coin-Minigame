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
		[SerializeField] private UnityEvent<int> OnGain;
		[SerializeField] private UnityEvent<int> OnLose;
		[SerializeField] private int lives;
		
		public static event Action<int> OnStaticGain;
		public static event Action<int> OnStaticLose;

		public void GainLife()
		{
			lives++;
			OnStaticGain?.Invoke(lives);
			OnGain?.Invoke(lives);
		}
    
		public void LoseLife()
		{
			lives--;
			if (lives == 0)
			{
				Die();
			}
			else
			{
				OnStaticLose?.Invoke(lives);
				OnLose?.Invoke(lives);
			}
		}

		private void Die()
		{
			SceneManager.LoadScene("DeathScreen");
		}
	}
}