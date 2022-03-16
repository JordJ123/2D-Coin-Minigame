﻿namespace Achievement
{
	public class DeathAFKController : AchievementController
	{
		private bool isFailed = false;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("AFK Death", "Die without moving");
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.TriggerDetector.OnDeath += CheckAchievement;
				Player.MovementController.OnMove += FailAchievement;
			}
		}

		private void CheckAchievement()
		{
			if (!isFailed)
			{
				achievementSystem.Unlock(achievement);
				Player.TriggerDetector.OnDeath -= CheckAchievement;
				Player.MovementController.OnMove -= FailAchievement;
			}
			else
			{
				isFailed = false;
				Player.MovementController.OnMove += FailAchievement;
			}
		}

		private void FailAchievement(bool ignore)
		{
			isFailed = true;
			Player.MovementController.OnMove -= FailAchievement;
		}
	}
}