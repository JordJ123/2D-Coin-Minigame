namespace Player.Achievement.Life
{
	public class LifeFirstController : AchievementController
	{
		private LivesController livesController;
		
		private void Awake()
		{
			livesController = transform.parent.GetComponent<LivesController>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("First Life");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				livesController.OnGain.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int ignore)
		{
			saveDataController.UnlockAchievement(achievement);
			livesController.OnGain.RemoveListener(CheckAchievement);
		}
	}
}