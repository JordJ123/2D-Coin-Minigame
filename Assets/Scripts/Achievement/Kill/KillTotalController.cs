using UnityEngine;

namespace Achievement.Kill
{
	public class KillTotalController : AchievementController
	{
		[SerializeField] private int killCount;
		private int currentKillCount;
		
		private void Awake()
		{
			achievement = new Achievement("Total Kills", "Legend",
				string.Format("Kill {0} enemies in total", killCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentKillCount(
					(int) achievementSystem.GetProgress(achievement));
				Player.TriggerDetector.OnKill += CheckAchievement;
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
				achievementSystem.Unlock(achievement);
				Player.TriggerDetector.OnKill -= CheckAchievement;
			}
			achievementSystem.SaveProgress(achievement, currentKillCount);
		}
	}
}