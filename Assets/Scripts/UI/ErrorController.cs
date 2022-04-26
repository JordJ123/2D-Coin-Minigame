using Screen.MenuScreen;
using TMPro;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ErrorController : MonoBehaviour
	{
		private GameObject audioGameObject;
		private MenuSoundController audio;
		private TextMeshProUGUI text;
        
		private void Awake()
		{
			text = GetComponent<TextMeshProUGUI>();
			text.text = "";
		}

		private void Start()
		{
			audioGameObject = GameObject.FindWithTag("Sound");
			if (audioGameObject != null)
			{
				audio = audioGameObject.GetComponent<MenuSoundController>();
			}
		}

		public void DisplayError(string errorMessage)
		{
			if (audio != null) audio.ErrorSound();
			text.text = errorMessage;
		}

		public void RemoveError()
		{
			text.text = "";
		}
	}
}