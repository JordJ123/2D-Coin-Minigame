using UnityEngine;

namespace Achievement.Point
{
	public class PointLargeController : AchievementController
	{
		[SerializeField] private int pointsValue;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("Large Points",
				string.Format("Collect {0} points in one game", pointsValue));
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.PointController.OnCollect += CheckAchievement;
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= this.pointsValue)
			{
				achievementSystem.Unlock(achievement);
				Player.PointController.OnCollect -= CheckAchievement;
			}
		}
	}
}