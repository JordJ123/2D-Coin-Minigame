using UnityEngine;

namespace Player.Achievement.Life
{
	public class LifeLargeController : AchievementController
	{
		private LivesController livesController;
		private int currentLifeCount;
		
		private void Awake()
		{
			livesController = transform.parent.GetComponent<LivesController>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("Large Lives");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				livesController.OnGain.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int ignore)
		{
			currentLifeCount++;
			if (currentLifeCount >= achievementListController.livesLargeCount)
			{
				saveDataController.UnlockAchievement(achievement);
				livesController.OnGain.RemoveListener(CheckAchievement);
			}
		}
	}
}