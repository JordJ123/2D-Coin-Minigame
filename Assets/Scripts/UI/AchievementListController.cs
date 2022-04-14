using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Player.Achievement;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class AchievementListController : MonoBehaviour
	{
		private TextMeshProUGUI achievementList;
        
		private void Awake() {
			achievementList = GetComponent<TextMeshProUGUI>();
			achievementList.text = "";
		}

		public void DisplayAchievement(Achievement achievement, string colour)
		{
			achievementList.text +=
				"<b>" + "<color=" + colour + ">"  
				+ achievement.GetDisplayName() + "</b> "
				+ achievement.GetDescription() + "\n" + "</color>";
		}
	}
}