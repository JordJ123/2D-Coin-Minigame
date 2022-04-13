using UnityEngine;

namespace Player.Achievement.Death
{
	public class DeathTotalController : AchievementController
	{
		private TriggerDetector triggerDetector;
		private int currentDeathCount;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement
				= achievementListController.GetAchievement("Total Deaths");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentDeathCount((int) saveDataController
					.GetAchievementProgress(achievement));
				triggerDetector.OnDeath.AddListener(CheckAchievement);
			}
		}

		private void SetCurrentDeathCount(int currentDeathCount)
		{
			this.currentDeathCount = currentDeathCount;
		}

		private void CheckAchievement()
		{
			currentDeathCount++;
			if (currentDeathCount >= achievementListController.deathTotalCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnDeath.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(
				achievement, currentDeathCount);
		}
	}
}