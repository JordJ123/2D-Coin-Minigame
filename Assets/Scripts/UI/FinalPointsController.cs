using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class FinalPointsController : MonoBehaviour
	{
		private TextMeshProUGUI pointsText;

		private void Awake()
		{
			pointsText = GetComponent<TextMeshProUGUI>();
			pointsText.text = "";
		}
		
		public void Set(bool isPlayerOne, int points, bool bold)
        {
			if (isPlayerOne)
			{
				pointsText.text = "Player One:\n" + points;
			}
			else
			{
				pointsText.text = "Player Two:\n" + points;
			}

			if (bold)
			{
				pointsText.fontStyle = FontStyles.Bold;
			}
		}
	}
}

