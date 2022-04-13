using UnityEngine;

namespace Player.Achievement.Kill
{
	public class KillTotalController : AchievementController
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
				= achievementListController.GetAchievement("Total Kills");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentKillCount((int) saveDataController
					.GetAchievementProgress(achievement));
				triggerDetector.OnKill.AddListener(CheckAchievement);
			}
		}
		
		private void SetCurrentKillCount(int currentKillCount)
		{
			this.currentKillCount = currentKillCount;
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= achievementListController.killsTotalCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnKill.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(
				achievement, currentKillCount);
		}
	}
}