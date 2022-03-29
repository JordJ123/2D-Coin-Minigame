namespace Player.Achievement.Kill
{
	public class KillFirstController : AchievementController
	{
		private TriggerDetector triggerDetector;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("First Kill", "Knight",
				"Kill your first enemy", transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
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