using System;
using UnityEngine;

namespace Achievement.Life
{
	public class LifeHaveController : AchievementController
	{
		[SerializeField] private int livesCount;
		
		private void Awake()
		{
			achievement = new Achievement("Have Lives", "Escape Artist",
				string.Format("Have {0} lives at one time", livesCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				Player.LivesController.OnStaticGain += CheckAchievement;
			}
		}

		private void CheckAchievement(int livesCount)
		{
			if (livesCount >= this.livesCount)
			{
				achievementSystem.Unlock(achievement);
				Player.LivesController.OnStaticGain -= CheckAchievement;
			}
		}
	}
}