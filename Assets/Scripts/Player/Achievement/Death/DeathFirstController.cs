namespace Player.Achievement.Death
{
	public class DeathFirstController : AchievementController
	{
		private TriggerDetector triggerDetector;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement =
				achievementListController.GetAchievement("First Death");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnDeath.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			saveDataController.UnlockAchievement(achievement);
			triggerDetector.OnDeath.RemoveListener(CheckAchievement);
		}
	}
}