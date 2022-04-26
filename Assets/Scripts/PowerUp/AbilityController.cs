using Screen;
using UnityEngine;
using UnityEngine.Events;

namespace PowerUp
{
	public abstract class AbilityController : MonoBehaviour
	{
		[SerializeField] public UnityEvent OnCollect;
		private SoundController soundController;
		private AudioSource audioSource;

		protected void Awake()
		{
			soundController = FindObjectOfType<SoundController>();
			audioSource = GetComponent<AudioSource>();
		}

		public abstract void Ability(GameObject player);
		
		protected void Collect()
		{
			OnCollect?.Invoke();
			soundController.PlaySound(audioSource.clip);
		}
	}
}
