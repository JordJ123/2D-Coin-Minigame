using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ProfileController : MonoBehaviour
	{
		private TextMeshProUGUI profileText;
        
		private void Awake()
		{
			profileText = GetComponent<TextMeshProUGUI>();
		}
		
		public void DisplayProfileName(string profileName)
		{
			profileText.text = profileName;
		}
	}
}