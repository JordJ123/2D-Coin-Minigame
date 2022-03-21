using System.Collections;
using System.Collections.Generic;
using Achievement;
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
			AchievementSystem.OnDisplay += DisplayAchievement;
			AchievementSystem.OnRemove += RemoveAchievement;
		}

		private void OnDisable()
		{
			AchievementSystem.OnDisplay -= DisplayAchievement;
			AchievementSystem.OnRemove -= RemoveAchievement;
		}
        
		public void DisplayAchievement(Achievement.Achievement achievement)
		{
			achievementDisplay.text = "Achievement Unlocked: " 
				+ achievement.GetDisplayName();
		}

		public void RemoveAchievement()
		{
			achievementDisplay.text  = "";
		}
	}
}