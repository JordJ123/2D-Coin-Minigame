using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class AchievementData : SaveData
	{
		private List<string> unlockedAchievements = new List<string>();

		public AchievementData(string name) : base(name) {}
		
		public void UnlockAchievement(Achievement.Achievement achievement)
		{
			unlockedAchievements.Add(achievement.GetIdName());
			SaveDataSystem.Save(this);
		}

		public bool HasAchievement(Achievement.Achievement achievement)
		{
			return unlockedAchievements.Contains(achievement.GetIdName());
		}
	}
}