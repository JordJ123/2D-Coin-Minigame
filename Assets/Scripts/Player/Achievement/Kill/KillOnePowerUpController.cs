using UnityEngine;

namespace Player.Achievement.Kill
{
	public class KillOnePowerUpController : AchievementController
	{
		private PowerUpController powerUpController;
		private TriggerDetector triggerDetector;
		private int currentKillCount;
		
		private void Awake()
		{
			powerUpController = transform.parent
				.GetComponent<PowerUpController>();
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement = 
				achievementListController.GetAchievement("One Power-Up Kills");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				powerUpController.OnAttackReset.AddListener(FailAchievement);
				triggerDetector.OnKill.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= 
				achievementListController.killsOnePowerUpCount)
			{
				saveDataController.UnlockAchievement(achievement);
				powerUpController.OnAttackReset.RemoveListener(FailAchievement);
				triggerDetector.OnKill.RemoveListener(CheckAchievement);
			}
			
		}

		private void FailAchievement()
		{
			currentKillCount = 0;
		}
	}
}