using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointNoKillController : AchievementController
	{
		[SerializeField] private int pointsValue;
		private PointController pointController;
		private TriggerDetector triggerDetector;
		
		private void Awake()
		{
			pointController = transform.parent.GetComponent<PointController>();
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("No Kills Points", "Pacifist",
				string.Format("Collect {0} points without getting a kill in one"
					+ " game", pointsValue), transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				pointController.OnCollect.AddListener(CheckAchievement);
				triggerDetector.OnKill.AddListener(FailAchievement);
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= this.pointsValue)
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