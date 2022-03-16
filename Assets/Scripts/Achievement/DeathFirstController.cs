namespace Achievement
{
	public class DeathFirstController : AchievementController
	{
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("First Death",
				"Experience your first death");
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.TriggerDetector.OnDeath += CheckAchievement;
			}
		}

		private void CheckAchievement()
		{
			achievementSystem.Unlock(achievement);
			Player.TriggerDetector.OnDeath -= CheckAchievement;
		}
	}
}