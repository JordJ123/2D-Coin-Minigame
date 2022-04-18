using Screen;
using UnityEngine;

namespace PowerUp
{
	public abstract class AbilityController : MonoBehaviour
	{
		private SoundController soundController;
		private AudioSource audioSource;
		private SpawnController spawnController;
		
		protected void Awake()
		{
			soundController = FindObjectOfType<SoundController>();
			audioSource = GetComponent<AudioSource>();
			spawnController = GetComponent<SpawnController>();
		}

		public abstract void Ability(GameObject player);
		
		protected void Collect()
		{
			soundController.PlaySound(audioSource.clip);
			spawnController.Despawn();
		}
	}
}
