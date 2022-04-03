using System.Collections;
using System.Collections.Generic;
using PowerUp;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class KeyController : MonoBehaviour
	{
		private static List<string> keys = new List<string>();
		private TextMeshProUGUI keyText;
		private int keyIndex;
        
        private void Awake() {
			keyText = GetComponent<TextMeshProUGUI>();
			keys.Add(keyText.text);
			keyIndex = keys.Count - 1;
		}
		
		public void DisplayKeys()
		{
			keyIndex++;
			if (keyIndex > keys.Count - 1)
			{
				keyIndex = 0;
			}
			keyText.text = keys[keyIndex];
		}
	}
}

