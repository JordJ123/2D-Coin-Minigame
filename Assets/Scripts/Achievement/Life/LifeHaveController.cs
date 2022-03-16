using System;
using UnityEngine;

namespace Achievement.Life
{
	public class LifeHaveController : AchievementController
	{
		[SerializeField] private int livesCount;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("Have Lives",
				string.Format("Have {0} lives at one time", livesCount));
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.LivesController.OnGain += CheckAchievement;
			}
		}

		private void CheckAchievement(int livesCount)
		{
			if (livesCount >= this.livesCount)
			{
				achievementSystem.Unlock(achievement);
				Player.LivesController.OnGain -= CheckAchievement;
			}
		}
	}
}