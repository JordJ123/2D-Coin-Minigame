using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PointController : MonoBehaviour
    {
        private TextMeshProUGUI pointsText;
        
        private void Awake()
        {
			pointsText = GetComponent<TextMeshProUGUI>();
			Player.PointController.OnCollect += UpdatePoints;
		}
		
		private void OnDisable()
		{
			Player.PointController.OnCollect -= UpdatePoints;
		}
        
        private void UpdatePoints(int points)
        {
			pointsText.text = "Points: " + points.ToString();
        }
    }
}

