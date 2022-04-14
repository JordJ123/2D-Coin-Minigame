using System;
using UnityEngine;

namespace Screen
{
	public class SoundEffectController : MonoBehaviour
	{
		[SerializeField] private AudioClip errorSound;
		[SerializeField] private AudioClip forwardSound;
		[SerializeField] private AudioClip loadSound;
		[SerializeField] private AudioClip saveSound;
		private AudioSource audioSource;
		private void Awake()
		{
			
			DontDestroyOnLoad(gameObject);
			audioSource = GetComponent<AudioSource>();
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
		
		public void SaveSound()
		{
			audioSource.PlayOneShot(loadSound);
		}
	}
}