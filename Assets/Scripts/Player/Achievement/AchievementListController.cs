using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player.Achievement
{
	public class AchievementListController : MonoBehaviour
	{
		[SerializeField] private Color achievementColour;
		[SerializeField] public int deathSmallCount;
		[SerializeField] public int deathLargeCount;
		[SerializeField] public int deathTotalCount;
		[SerializeField] public int killsSmallCount;
		[SerializeField] public int killsLargeCount;
		[SerializeField] public int killsTotalCount;
		[SerializeField] public int killsOnePowerUpCount;
		[SerializeField] public int livesSmallCount;
		[SerializeField] public int livesLargeCount;
		[SerializeField] public int livesTotalCount;
		[SerializeField] public int livesHaveCount;
		[SerializeField] public int pointsSmallValue;
		[SerializeField] public int pointsLargeValue;
		[SerializeField] public int pointsTotalValue;
		[SerializeField] public int pointsNoKillsValue;
		[SerializeField] public float speedSmallCount;
		[SerializeField] public float speedLargeCount;
		[SerializeField] public float speedTotalCount;
		[SerializeField] public float speedOnePowerUpCount;
		private Dictionary<string, Achievement> achievements 
			= new Dictionary<string, Achievement>();

		private void Awake()
		{
			Achievement achievement;
			
			//Death Achievements
			achievement = new Achievement("First Death", "Initiation",
				"Experience your first death", achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Small Deaths", 
				"Took a Zombie to the Knee",
				string.Format("Experience {0} deaths in one game", 
					deathSmallCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Large Deaths", "Fus Ro Die",
				string.Format("Experience {0} deaths in one game", 
				deathLargeCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Total Deaths", "Elder Ring", 
				string.Format("Experience {0} deaths in total", 
				deathTotalCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("AFK Death", "AFKnight", 
				"Die without moving", achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			
			//Kill Achievements
			achievement = new Achievement("First Kill", "Knight",
				"Kill your first enemy", achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Small Kills", "Commander",
				string.Format("Kill {0} enemies in one game", killsSmallCount), 
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Large Kills", "Grand Cross",
				string.Format("Kill {0} enemies in one game", killsLargeCount),
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Total Kills", "Legend",
				string.Format("Kill {0} enemies in total", killsTotalCount),
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("One Power-Up Kills", "Bloodbath",
				string.Format("Kill {0} enemies during one attack power-up", 
					killsOnePowerUpCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			
			//Life Achievements
			achievement = new Achievement("First Life", "1UP",
				"Gain your first extra life", achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Small Lives", 
				"Knight in Shining Armor",
				string.Format("Gain {0} lives in one game", livesSmallCount), 
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Large Lives", 
				"Marvelous Black Knight",
				string.Format("Gain {0} lives in one game", livesLargeCount), 
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Total Lives", "The Dark Knight",
				string.Format("Gain {0} lives in total", livesTotalCount), 
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Have Lives", "Escape Artist",
				string.Format("Have {0} lives at one time", livesHaveCount),
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);

			//Point Achievements
			achievement = new Achievement("First Point", "Peasant",
				"Collect your first point", achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Small Points", "Noble",
				string.Format("Collect {0} points in one game", 
				pointsSmallValue), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Large Points", "Royalty",
				string.Format("Collect {0} points in one game", 
					pointsLargeValue), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Total Points", 
				"The Lord of the Coins", 
				string.Format("Collect {0} points in total", pointsTotalValue),
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("No Kills Points", "Pacifist",
				string.Format("Collect {0} points without getting a kill in one"
					+ " game", pointsNoKillsValue), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			
			//Speed Achievements
			achievement = new Achievement("First Speed Movement", "First Steps",
				"Move with the speed power-up for the first time", 
				achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Small Speed Movement", 
				"Knight and his Steed", string.Format(
					"Move with the speed power-up a distance of {0} in one game", 
					speedSmallCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Large Speed Movement", 
				"Diogooooooooo Jota!!!", string.Format(
					"Move with the speed power-up a distance of {0} in one game", 
					speedLargeCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("Total Speed Movement", 
				"The Knights of Run", string.Format(
					"Move with the speed power-up a distance of {0} in total", 
					speedTotalCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
			achievement = new Achievement("One Power-Up Speed Movement", 
				"Sonic and the Blue Knight", 
				string.Format("Move a distance of {0} within one speed power-up", 
					speedOnePowerUpCount), achievementColour);
			achievements.Add(achievement.GetIdName(), achievement);
		}
		
		public List<Achievement> GetAchievements()
		{
			return achievements.Values.ToList();
		}

		public Achievement GetAchievement(string idName)
		{
			if (!achievements.ContainsKey(idName))
			{
				throw new ArgumentException(idName + " is not an id name");
			}
			return achievements[idName];
		}
	}
}