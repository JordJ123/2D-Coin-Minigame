using System.Collections;
using System.Collections.Generic;
using Screen;
using TMPro;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ErrorController : MonoBehaviour
	{
	    private SoundEffectController audio;
		private TextMeshProUGUI text;
        
		private void Awake()
		{
			audio = GameObject.FindWithTag("Sound")
				.GetComponent<SoundEffectController>();
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