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
        }
        
        public void UpdateLives(int lives)
        {
			livesText.text = "Lives: " + lives.ToString();
        }
    }
}

