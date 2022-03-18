using UnityEngine;

namespace Achievement.Speed
{
	public class SpeedFirstController : AchievementController
	{
		private void Awake()
		{
			achievement = new Achievement("First Speed Movement",
				"Move with the speed power-up for the first time");
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				Player.MovementController.OnMove += CheckAchievement;
			}
		}

		private void CheckAchievement(bool hasSpeedPowerUp, Transform ignore)
		{
			if (hasSpeedPowerUp)
			{
				achievementSystem.Unlock(achievement);
				Player.MovementController.OnMove -= CheckAchievement;
			}
		}
	}
}