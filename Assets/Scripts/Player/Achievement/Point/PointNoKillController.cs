using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointNoKillController : AchievementController
	{
		private PointController pointController;
		private TriggerDetector triggerDetector;
		
		private void Awake()
		{
			pointController = transform.parent.GetComponent<PointController>();
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("No Kills Points");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				pointController.OnCollect.AddListener(CheckAchievement);
				triggerDetector.OnKill.AddListener(FailAchievement);
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= achievementListController.pointsNoKillsValue)
			{
				saveDataController.UnlockAchievement(achievement);
				pointController.OnCollect.RemoveListener(CheckAchievement);
				triggerDetector.OnKill.RemoveListener(FailAchievement);
			}
		}

		private void FailAchievement()
		{
			pointController.OnCollect.RemoveListener(CheckAchievement);
			triggerDetector.OnKill.RemoveListener(FailAchievement);
		}
	}
}