using UnityEngine;

namespace Screen
{
	[RequireComponent(typeof(AudioSource))]
	public class SoundController : MonoBehaviour
	{
		private AudioSource audioSource;
		
		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
		}

		public void PlaySound(AudioClip audioClip)
		{
			audioSource.PlayOneShot(audioClip);
		}
		
		public void PlaySound(AudioClip audioClip, float volume)
		{
			audioSource.PlayOneShot(audioClip, volume);
		}
	}
}