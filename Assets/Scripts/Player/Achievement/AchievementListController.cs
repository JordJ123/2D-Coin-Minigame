using System.Collections.Generic;
using UnityEngine;

namespace Player.Achievement
{
	public class AchievementListController : MonoBehaviour
	{
		private Dictionary<string, Achievement> achievements
			= new Dictionary<string, Achievement>();

		private void Awake()
		{
			
		}

		public Achievement GetAchievement(string idName)
		{
			return achievements[idName];
		}
	}
}