namespace Achievement.Kill
{
	public class KillFirstController : AchievementController
	{
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("First Kill",
				"Kill your first enemy");
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
			achievementSystem.Unlock(achievement);
			Player.TriggerDetector.OnKill -= CheckAchievement;
		}
	}
}