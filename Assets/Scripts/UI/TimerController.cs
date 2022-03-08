using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TimerController : MonoBehaviour
    {
        private TextMeshProUGUI timerText;
        
        private void Awake() {
			timerText = GetComponent<TextMeshProUGUI>();
			timerText.text = "";
		}
        
        public void UpdateSeconds(int seconds)
        {
			timerText.text = seconds.ToString();
        }

		public void EndTimer()
		{
			timerText.text = "";
		}
    }
}

