using System.Collections;
using System.Collections.Generic;
using Screen.GameScreen;
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
			AchievementDisplayController.OnDisplay += DisplayAchievement;
			AchievementDisplayController.OnRemove += RemoveAchievement;
		}
		
		private void OnDisable()
		{
			AchievementDisplayController.OnDisplay -= DisplayAchievement;
			AchievementDisplayController.OnRemove -= RemoveAchievement;
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