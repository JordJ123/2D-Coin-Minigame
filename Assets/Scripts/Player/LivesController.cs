using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
	public class LivesController : MonoBehaviour
	{
		[SerializeField] private UI.LivesController ui;
		[SerializeField] private int lives;

		public void GainLife()
		{
			lives++;
			ui.UpdateLives(lives);
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
				ui.UpdateLives(lives);
			}
		}

		private void Die()
		{
			SceneManager.LoadScene("DeathScreen");
		}
	}
}