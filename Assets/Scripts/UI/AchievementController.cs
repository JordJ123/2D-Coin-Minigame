using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class AchievementController : MonoBehaviour
	{
		private TextMeshProUGUI achievementDisplay;
        
		private void Awake() {
			achievementDisplay = GetComponent<TextMeshProUGUI>();
			achievementDisplay.text = "";
		}
        
		public void DisplayAchievement(Achievement.Achievement achievement)
		{
			achievementDisplay.text = "Achievement Unlocked: " 
				+ achievement.GetName();
		}

		public void RemoveAchievement()
		{
			achievementDisplay.text  = "";
		}
	}
}