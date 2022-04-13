using UnityEngine;

namespace Player.Achievement.Life
{
	public class LifeTotalController : AchievementController
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
				= achievementListController.GetAchievement("Total Lives");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentLifeCount((int) saveDataController
					.GetAchievementProgress(achievement));
				livesController.OnGain.AddListener(CheckAchievement);
			}
		}
		
		private void SetCurrentLifeCount(int currentLifeCount)
		{
			this.currentLifeCount = currentLifeCount;
		}

		private void CheckAchievement(int ignore)
		{
			currentLifeCount++;
			if (currentLifeCount >= achievementListController.livesTotalCount)
			{
				saveDataController.UnlockAchievement(achievement);
				livesController.OnGain.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(
				achievement, currentLifeCount);
		}
	}
}