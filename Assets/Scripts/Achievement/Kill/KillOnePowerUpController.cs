using UnityEngine;

namespace Achievement.Kill
{
	public class KillOnePowerUpController : AchievementController
	{
		[SerializeField] private int killCount;
		private int currentKillCount;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("One Power-Up Kills", string.Format(
				"Kill {0} enemies during one attack power-up", killCount));
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.TriggerDetector.OnKill += CheckAchievement;
				PowerUpController.OnAttackReset += FailAchievement;
			}
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= killCount)
			{
				achievementSystem.Unlock(achievement);
				Player.TriggerDetector.OnKill -= CheckAchievement;
				PowerUpController.OnAttackReset -= FailAchievement;
			}
			
		}

		private void FailAchievement()
		{
			currentKillCount = 0;
		}
	}
}