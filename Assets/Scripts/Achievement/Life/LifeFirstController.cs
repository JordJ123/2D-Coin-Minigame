namespace Achievement.Life
{
	public class LifeFirstController : AchievementController
	{
		private void Awake()
		{
			achievement = new Achievement("First Life", "1UP",
				"Gain your first extra life");
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
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