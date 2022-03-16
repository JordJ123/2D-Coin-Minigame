namespace Achievement
{
	public class SpeedFirstController : AchievementController
	{
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("First Speed Movement",
				"Move with the speed power-up for the first time");
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.MovementController.OnMove += CheckAchievement;
			}
		}

		private void CheckAchievement(bool hasSpeedPowerUp)
		{
			if (hasSpeedPowerUp)
			{
				achievementSystem.Unlock(achievement);
				Player.MovementController.OnMove -= CheckAchievement;
			}
		}
	}
}