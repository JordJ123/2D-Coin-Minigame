using System;
using UnityEngine;

namespace Player.Achievement.Life
{
	public class LifeHaveController : AchievementController
	{
		[SerializeField] private int livesCount;
		private LivesController livesController;
		
		private void Awake()
		{
			livesController = transform.parent.GetComponent<LivesController>();
			achievement = new Achievement("Have Lives", "Escape Artist",
				string.Format("Have {0} lives at one time", livesCount),
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				livesController.OnGain.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int livesCount)
		{
			if (livesCount >= this.livesCount)
			{
				saveDataController.UnlockAchievement(achievement);
				livesController.OnGain.RemoveListener(CheckAchievement);
			}
		}
	}
}