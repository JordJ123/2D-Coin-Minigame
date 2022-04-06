using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {
    public class PauseController : MonoBehaviour
	{
		private GameObject menu;
		private GameObject pauseButton;

		private void Awake()
		{
			pauseButton = GameObject.Find("Pause Button");
			menu = GameObject.Find("Pause Menu");
			menu.SetActive(false);
		}

		public void Pause()
		{
			pauseButton.SetActive(false);
			menu.SetActive(true);
			Time.timeScale = 0;
		}
        
        public void Play()
		{
			pauseButton.SetActive(true);
			menu.SetActive(false);
			Time.timeScale = 1;
		}

		public void Quit()
		{
			SceneManager.LoadScene("MenuScreen");
		}
    }
}

