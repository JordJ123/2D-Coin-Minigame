using UnityEngine;

namespace Achievement.Point
{
	public class PointNoKillController : AchievementController
	{
		[SerializeField] private int pointsValue;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("No Kills Points",
				string.Format("Collect {0} points without getting a kill in one"
					+ " game", pointsValue));
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.PointController.OnCollect += CheckAchievement;
				Player.TriggerDetector.OnKill += FailAchievement;
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= this.pointsValue)
			{
				achievementSystem.Unlock(achievement);
				Player.PointController.OnCollect -= CheckAchievement;
				Player.TriggerDetector.OnKill -= FailAchievement;
			}
		}

		private void FailAchievement()
		{
			Player.PointController.OnCollect -= CheckAchievement;
			Player.TriggerDetector.OnKill -= FailAchievement;
		}
	}
}