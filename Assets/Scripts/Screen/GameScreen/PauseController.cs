using UnityEngine;
using UnityEngine.SceneManagement;


namespace Screen.GameScreen {
    public class PauseController : MonoBehaviour
	{
		private SoundEffectController audio;
		private GameObject menu;
		private GameObject pauseButton;

		private void Awake()
		{
			audio = GameObject.FindWithTag("Sound")
				.GetComponent<SoundEffectController>();
			pauseButton = GameObject.Find("Pause Button");
			menu = GameObject.Find("Pause Menu");
			menu.SetActive(false);
		}

		public void Pause()
		{
			if (audio != null) audio.PauseSound();
			pauseButton.SetActive(false);
			menu.SetActive(true);
			Time.timeScale = 0;
		}
        
        public void Play()
		{
			if (audio != null) audio.UnpauseSound();
			pauseButton.SetActive(true);
			menu.SetActive(false);
			Time.timeScale = 1;
		}

		public void Quit()
		{
			if (audio != null) audio.BackwardSound();
			SceneManager.LoadScene("MenuScreen");
		}
    }
}

