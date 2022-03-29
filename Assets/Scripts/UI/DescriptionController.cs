using System.Collections;
using System.Collections.Generic;
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
			Manager.AchievementManager.OnDisplay += DisplayAchievement;
			Manager.AchievementManager.OnRemove += RemoveAchievement;
		}
		
		private void OnDisable()
		{
			Manager.AchievementManager.OnDisplay -= DisplayAchievement;
			Manager.AchievementManager.OnRemove -= RemoveAchievement;
		}
        
		public void DisplayAchievement(
			Player.Achievement.Achievement achievement)
		{
			achievementDisplay.color = achievement.GetColour();
			achievementDisplay.text = achievement.GetDescription();
		}

		public void RemoveAchievement()
		{
			achievementDisplay.text  = "";
		}
	}
}