using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace  Screen
{
	public class DeathScreenController : MonoBehaviour
	{
		private SoundEffectController audio;
    
		private void Awake()
		{
			audio = GameObject.FindWithTag("Sound")
				.GetComponent<SoundEffectController>();
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
