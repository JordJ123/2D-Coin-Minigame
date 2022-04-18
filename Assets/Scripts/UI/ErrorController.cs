using Screen.MenuScreen;
using TMPro;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ErrorController : MonoBehaviour
	{
	    private MenuSoundController audio;
		private TextMeshProUGUI text;
        
		private void Awake()
		{
			audio = GameObject.FindWithTag("Sound")
				.GetComponent<MenuSoundController>();
			text = GetComponent<TextMeshProUGUI>();
			text.text = "";
		}

		public void DisplayError(string errorMessage)
		{
			audio.ErrorSound();
			text.text = errorMessage;
		}

		public void RemoveError()
		{
			text.text = "";
		}
	}
}