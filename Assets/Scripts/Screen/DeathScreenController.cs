using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screen
{
	public class DeathScreenController : MonoBehaviour
	{
		private GameObject audioGameObject;
		private SoundEffectController audio;
    
		private void Awake()
		{
			audioGameObject = GameObject.FindWithTag("Sound");
			if (audioGameObject != null)
			{
				audio = audioGameObject.GetComponent<SoundEffectController>();
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
