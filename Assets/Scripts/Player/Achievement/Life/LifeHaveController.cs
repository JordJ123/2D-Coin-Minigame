using System;
using UnityEngine;

namespace Player.Achievement.Life
{
	public class LifeHaveController : AchievementController
	{
		private LivesController livesController;
		
		private void Awake()
		{
			livesController = transform.parent.GetComponent<LivesController>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("Have Lives");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				livesController.OnGain.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int livesCount)
		{
			if (livesCount >= achievementListController.livesHaveCount)
			{
				saveDataController.UnlockAchievement(achievement);
				livesController.OnGain.RemoveListener(CheckAchievement);
			}
		}
	}
}