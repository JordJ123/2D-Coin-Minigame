using UnityEngine;

namespace Player.Achievement.Kill
{
	public class KillOnePowerUpController : AchievementController
	{
		[SerializeField] private int killCount;
		private PowerUpController powerUpController;
		private TriggerDetector triggerDetector;
		private int currentKillCount;
		
		private void Awake()
		{
			powerUpController = transform.parent
				.GetComponent<PowerUpController>();
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("One Power-Up Kills", "Bloodbath",
				string.Format("Kill {0} enemies during one attack power-up", 
				killCount), transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				powerUpController.OnAttackReset.AddListener(FailAchievement);
				triggerDetector.OnKill.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= killCount)
			{
				saveDataController.UnlockAchievement(achievement);
				powerUpController.OnAttackReset.RemoveListener(FailAchievement);
				triggerDetector.OnKill.RemoveListener(CheckAchievement);
			}
			
		}

		private void FailAchievement()
		{
			currentKillCount = 0;
		}
	}
}