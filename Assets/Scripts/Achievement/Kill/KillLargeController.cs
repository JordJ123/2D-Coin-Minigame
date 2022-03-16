using UnityEngine;

namespace Achievement.Kill
{
	public class KillLargeController : AchievementController
	{
		[SerializeField] private int killCount;
		private int currentKillCount;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("Large Kills",
				string.Format("Kill {0} enemies in one game", killCount));
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.TriggerDetector.OnKill += CheckAchievement;
			}
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= killCount)
			{
				achievementSystem.Unlock(achievement);
				Player.TriggerDetector.OnKill -= CheckAchievement;
			}
			
		}
	}
}