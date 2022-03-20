namespace Achievement.Kill
{
	public class KillFirstController : AchievementController
	{
		private void Awake()
		{
			achievement = new Achievement("First Kill", "Knight",
				"Kill your first enemy");
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
			achievementSystem.Unlock(achievement);
			Player.TriggerDetector.OnKill -= CheckAchievement;
		}
	}
}