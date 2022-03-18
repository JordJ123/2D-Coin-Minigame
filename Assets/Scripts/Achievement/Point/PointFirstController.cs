﻿using UnityEngine;

namespace Achievement.Point
{
	public class PointFirstController : AchievementController
	{
		private void Awake()
		{
			achievement = new Achievement("First Point", 
				"Collect your first point");
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				Player.PointController.OnCollect += CheckAchievement;
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue > 0)
			{
				achievementSystem.Unlock(achievement);
				Player.PointController.OnCollect -= CheckAchievement;
			}
		}
	}	
}