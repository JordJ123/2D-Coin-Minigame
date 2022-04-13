using UnityEngine;

namespace Player.Achievement.Death
{
	public class DeathSmallController : AchievementController
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
				= achievementListController.GetAchievement("Small Deaths");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnDeath.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentDeathCount++;
			if (currentDeathCount >= achievementListController.deathSmallCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnDeath.RemoveListener(CheckAchievement);
			}
		}
	}
}