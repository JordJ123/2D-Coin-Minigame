using UnityEngine;

namespace Achievement.Death
{
	public class DeathAFKController : AchievementController
	{
		private bool isFailed;
		
		private void Awake()
		{
			achievement = new Achievement("AFK Death", "AFKnight", 
				"Die without moving");
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				Player.TriggerDetector.OnStaticDeath += CheckAchievement;
				Player.MovementController.OnMove += FailAchievement;
			}
		}

		private void CheckAchievement()
		{
			if (!isFailed)
			{
				achievementSystem.Unlock(achievement);
				Player.TriggerDetector.OnStaticDeath -= CheckAchievement;
				Player.MovementController.OnMove -= FailAchievement;
			}
			else
			{
				isFailed = false;
				Player.MovementController.OnMove += FailAchievement;
			}
		}

		private void FailAchievement(bool ignore, Transform ignore2)
		{
			isFailed = true;
			Player.MovementController.OnMove -= FailAchievement;
		}
	}
}