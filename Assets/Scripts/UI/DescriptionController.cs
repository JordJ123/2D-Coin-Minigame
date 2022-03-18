using System.Collections;
using System.Collections.Generic;
using Achievement;
using TMPro;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class DescriptionController : MonoBehaviour
	{
		private TextMeshProUGUI achievementDisplay;
        
		private void Awake() {
			achievementDisplay = GetComponent<TextMeshProUGUI>();
			achievementDisplay.text = "";
			AchievementSystem.OnDisplay += DisplayAchievement;
			AchievementSystem.OnRemove += RemoveAchievement;
		}
        
		public void DisplayAchievement(Achievement.Achievement achievement)
		{
			achievementDisplay.text = achievement.GetDescription();
		}

		public void RemoveAchievement()
		{
			achievementDisplay.text  = "";
		}
	}
}