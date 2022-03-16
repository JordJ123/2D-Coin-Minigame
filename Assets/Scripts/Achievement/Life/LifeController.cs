namespace Achievement.Life
{
	public class LifeController : AchievementController
	{
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("First Life",
				"Gain your first extra life");
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.LivesController.OnGain += CheckAchievement;
			}
		}

		private void CheckAchievement(int ignore)
		{
			achievementSystem.Unlock(achievement);
			Player.LivesController.OnGain -= CheckAchievement;
		}
	}
}