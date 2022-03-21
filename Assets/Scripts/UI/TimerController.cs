using System.Collections;
using System.Collections.Generic;
using PowerUp;
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
			TimedAbilityController.OnSecond += UpdateSeconds;
		}
		
		private void OnDisable()
		{
			TimedAbilityController.OnSecond -= UpdateSeconds;
		}
        
        public void UpdateSeconds(int seconds)
        {
			if (seconds != 0)
			{
				timerText.text = seconds.ToString();
			}
			else
			{
				timerText.text = "";
			}
		}
	}
}

