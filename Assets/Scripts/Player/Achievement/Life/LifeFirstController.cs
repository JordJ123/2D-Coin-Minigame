namespace Player.Achievement.Life
{
	public class LifeFirstController : AchievementController
	{
		private LivesController livesController;
		
		private void Awake()
		{
			livesController = transform.parent.GetComponent<LivesController>();
			achievement = new Achievement("First Life", "1UP",
				"Gain your first extra life", transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
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