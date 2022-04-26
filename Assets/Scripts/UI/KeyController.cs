using System;
using System.Collections;
using System.Collections.Generic;
using PowerUp;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class KeyController : MonoBehaviour
	{
		private static List<Tuple<string, float>> keys 
			= new List<Tuple<string, float>>();
		private TextMeshProUGUI keyText;
		private int keyIndex;
        
        private void Awake() {
			keyText = GetComponent<TextMeshProUGUI>();
			keys.Add(new Tuple<string, float>(keyText.text, keyText.fontSize));
			keyIndex = keys.Count - 1;
		}
		
		public void DisplayKeys()
		{
			keyIndex++;
			if (keyIndex > keys.Count - 1)
			{
				keyIndex = 0;
			}
			keyText.text = keys[keyIndex].Item1;
			keyText.fontSize = keys[keyIndex].Item2;
		}
	}
}

