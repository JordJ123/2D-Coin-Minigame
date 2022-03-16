using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LivesController : MonoBehaviour
    {
        private TextMeshProUGUI livesText;
        
        private void Awake()
        {
			livesText = GetComponent<TextMeshProUGUI>();
			Player.LivesController.OnGain += UpdateLives;
			Player.LivesController.OnLose += UpdateLives;
		}
        
        private void UpdateLives(int lives)
		{
			livesText.text = "Lives: " + lives;
		}
    }
}

