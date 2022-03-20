using UnityEngine;

namespace Achievement.Kill
{
	public class KillLargeController : AchievementController
	{
		[SerializeField] private int killCount;
		private int currentKillCount;
		
		private void Awake()
		{
			achievement = new Achievement("Large Kills", "Grand Cross",
				string.Format("Kill {0} enemies in one game", killCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
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