using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
	public class LivesController : MonoBehaviour
	{
		[SerializeField] private int lives;
		
		public static event Action<int> OnGain;
		public static event Action<int> OnLose;

		public void GainLife()
		{
			lives++;
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
				OnLose?.Invoke(lives);
			}
		}

		private void Die()
		{
			SceneManager.LoadScene("DeathScreen");
		}
	}
}