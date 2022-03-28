using UnityEngine;

namespace Achievement.Point
{
	public class PointNoKillController : AchievementController
	{
		[SerializeField] private int pointsValue;
		
		private void Awake()
		{
			achievement = new Achievement("No Kills Points", "Pacifist",
				string.Format("Collect {0} points without getting a kill in one"
					+ " game", pointsValue));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				Player.PointController.OnStaticCollect += CheckAchievement;
				Player.TriggerDetector.OnKill += FailAchievement;
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= this.pointsValue)
			{
				achievementSystem.Unlock(achievement);
				Player.PointController.OnStaticCollect -= CheckAchievement;
				Player.TriggerDetector.OnKill -= FailAchievement;
			}
		}

		private void FailAchievement()
		{
			Player.PointController.OnStaticCollect -= CheckAchievement;
			Player.TriggerDetector.OnKill -= FailAchievement;
		}
	}
}