namespace Achievement.Death
{
	public class DeathFirstController : AchievementController
	{
		private void Awake()
		{
			achievement = new Achievement("First Death",
				"Experience your first death");
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
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