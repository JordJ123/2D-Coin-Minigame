using System;
using Screen.MenuScreen;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Screen
{
	public class DeathScreenController : MonoBehaviour
	{
		private GameObject audioGameObject;
		private MenuSoundController audio;
    
		private void Awake()
		{
			audioGameObject = GameObject.FindWithTag("Sound");
			if (audioGameObject != null)
			{
				audio = audioGameObject.GetComponent<MenuSoundController>();
			}
		}

		public void PlayAgain()
		{
			if (audio != null) audio.ForwardSound();
			SceneManager.LoadScene("GameScreen");
		}
    
		public void Return()
		{
			if (audio != null) audio.BackwardSound();
			SceneManager.LoadScene("MenuScreen");
		}
	}
}
