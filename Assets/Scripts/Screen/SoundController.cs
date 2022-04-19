using UnityEngine;

namespace Screen
{
	[RequireComponent(typeof(AudioSource))]
	public class SoundController : MonoBehaviour
	{
		protected AudioSource audioSource;
		
		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
		}

		public void PlaySound(AudioClip audioClip)
		{
			audioSource.PlayOneShot(audioClip, 1);
		}
		
		public void PlaySound(AudioClip audioClip, float volume)
		{
			audioSource.PlayOneShot(audioClip, volume);
		}
	}
}