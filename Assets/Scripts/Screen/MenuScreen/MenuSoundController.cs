using System;
using UnityEngine;

namespace Screen.MenuScreen
{
	public class MenuSoundController : MonoBehaviour
	{
		[SerializeField] private AudioClip backwardSound;
		[SerializeField] private AudioClip errorSound;
		[SerializeField] private AudioClip forwardSound;
		[SerializeField] private AudioClip loadSound;
		[SerializeField] private AudioClip pauseSound;
		[SerializeField] private AudioClip saveSound;
		[SerializeField] private AudioClip unpauseSound;
		private AudioSource audioSource;
		
		private void Awake()
		{
			
			DontDestroyOnLoad(gameObject);
			audioSource = GetComponent<AudioSource>();
		}
		
		public void BackwardSound()
		{
			audioSource.PlayOneShot(backwardSound);
		}
		
		public void ErrorSound()
		{
			audioSource.PlayOneShot(errorSound);
		}

		public void ForwardSound()
		{
			audioSource.PlayOneShot(forwardSound);
		}

		public void LoadSound()
		{
			audioSource.PlayOneShot(loadSound);
		}
		
		public void PauseSound()
		{
			audioSource.PlayOneShot(pauseSound);
		}
		
		public void SaveSound()
		{
			audioSource.PlayOneShot(saveSound);
		}
		
		public void UnpauseSound()
		{
			audioSource.PlayOneShot(unpauseSound);
		}
	}
}