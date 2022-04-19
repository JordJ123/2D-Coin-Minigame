using System;
using UnityEngine;

namespace Screen.MenuScreen
{
	public class MenuSoundController : SoundController
	{
		[SerializeField] private AudioClip backwardSound;
		[SerializeField] private AudioClip errorSound;
		[SerializeField] private AudioClip forwardSound;
		[SerializeField] private AudioClip loadSound;
		[SerializeField] private AudioClip pauseSound;
		[SerializeField] private AudioClip saveSound;
		[SerializeField] private AudioClip unpauseSound;
		private static MenuSoundController menuSoundController;

		private void Awake()
		{
			if (menuSoundController == null)
			{
				menuSoundController = this;
			}
			else
			{
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
			audioSource = GetComponent<AudioSource>();
		}
		
		public void BackwardSound()
		{
			PlaySound(backwardSound);
		}
		
		public void ErrorSound()
		{
			PlaySound(errorSound);
		}

		public void ForwardSound()
		{
			PlaySound(forwardSound);
		}

		public void LoadSound()
		{
			audioSource.PlayOneShot(loadSound);
		}
		
		public void PauseSound()
		{
			PlaySound(pauseSound);
		}
		
		public void SaveSound()
		{
			PlaySound(saveSound);
		}
		
		public void UnpauseSound()
		{
			PlaySound(unpauseSound);
		}
	}
}