using UnityEngine;

namespace Player.Achievement.Kill
{
	public class KillTotalController : AchievementController
	{
		[SerializeField] private int killCount;
		private TriggerDetector triggerDetector;
		private int currentKillCount;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("Total Kills", "Legend",
				string.Format("Kill {0} enemies in total", killCount),
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
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
			if (currentKillCount >= killCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnKill.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(
				achievement, currentKillCount);
		}
	}
}