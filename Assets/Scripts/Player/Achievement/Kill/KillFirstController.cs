namespace Player.Achievement.Kill
{
	public class KillFirstController : AchievementController
	{
		private TriggerDetector triggerDetector;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement = achievementListController.GetAchievement("First Kill");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnKill.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			saveDataController.UnlockAchievement(achievement);
			triggerDetector.OnKill.RemoveListener(CheckAchievement);
		}
	}
}