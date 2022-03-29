namespace Player.Achievement.Death
{
	public class DeathFirstController : AchievementController
	{
		private TriggerDetector triggerDetector;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("First Death", "Initiation",
				"Experience your first death", transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
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