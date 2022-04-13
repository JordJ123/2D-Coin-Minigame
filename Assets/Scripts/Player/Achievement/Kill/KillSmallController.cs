using UnityEngine;

namespace Player.Achievement.Kill
{
	public class KillSmallController : AchievementController
	{
		private TriggerDetector triggerDetector;
		private int currentKillCount;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("Small Kills");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnKill.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= achievementListController.killsSmallCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnKill.RemoveListener(CheckAchievement);
			}
			
		}
	}
}