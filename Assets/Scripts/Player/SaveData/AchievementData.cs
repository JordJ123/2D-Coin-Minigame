using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.SaveData
{
	[Serializable]
	public class AchievementData : SaveData
	{
		private List<string> unlockedAchievements = new List<string>();
		private Dictionary<string, float> achievementProgress =
			new Dictionary<string, float>();

		public AchievementData(string profileName) 
			: base(profileName + "/achievements") {}

		public List<string> GetUnlockedAchievements()
		{
			return unlockedAchievements;
		}
		
		public void UnlockAchievement(
			Player.Achievement.Achievement achievement)
		{
			unlockedAchievements.Add(achievement.GetIdName());
			Save(this);
		}

		public bool HasAchievement(
			Player.Achievement.Achievement achievement)
		{
			return unlockedAchievements.Contains(achievement.GetIdName());
		}

		public float GetProgress(Player.Achievement.Achievement achievement)
		{
			if (achievementProgress.ContainsKey(achievement.GetIdName()))
			{
				float progress;
				achievementProgress.TryGetValue(achievement.GetIdName(),
					out progress);
				return progress;
			}
			return 0;
		}

		public void SaveProgress(Achievement.Achievement achievement, 
			float data)
		{
			if (achievementProgress.ContainsKey(achievement.GetIdName()))
			{
				achievementProgress.Remove(achievement.GetIdName());
			}
			achievementProgress.Add(achievement.GetIdName(), data);
			Save(this);
		}
	}
}
