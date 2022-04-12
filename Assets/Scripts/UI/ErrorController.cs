using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ErrorController : MonoBehaviour
	{
		private TextMeshProUGUI error;
        
		private void Awake() {
			error = GetComponent<TextMeshProUGUI>();
		}

		public void DisplayError(string errorMessage)
		{
			error.text = errorMessage;
		}
	}
}