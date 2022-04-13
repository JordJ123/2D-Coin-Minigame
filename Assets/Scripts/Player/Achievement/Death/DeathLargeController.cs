using UnityEngine;

namespace Player.Achievement.Death
{
	public class DeathLargeController : AchievementController
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
				= achievementListController.GetAchievement("Large Deaths");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnDeath.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentDeathCount++;
			if (currentDeathCount >= achievementListController.deathLargeCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnDeath.RemoveListener(CheckAchievement);
			}
		}
	}
}