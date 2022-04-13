using UnityEngine;

namespace Player.Achievement.Kill
{
	public class KillLargeController : AchievementController
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
			achievement = achievementListController.GetAchievement("Large Kills");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnKill.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= achievementListController.killsLargeCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnKill.RemoveListener(CheckAchievement);
			}
			
		}
	}
}