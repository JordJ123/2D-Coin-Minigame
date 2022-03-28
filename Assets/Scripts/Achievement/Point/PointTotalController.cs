using UnityEngine;

namespace Achievement.Point
{
	public class PointTotalController : AchievementController
	{
		[SerializeField] private int pointsValue;
		private int savedPointsValue;
		
		private void Awake()
		{
			achievement = new Achievement("Total Points", 
				"The Lord of the Coins", 
				string.Format("Collect {0} points in total", pointsValue));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetSavedPointsValue(
					(int) achievementSystem.GetProgress(achievement));
				Player.PointController.OnStaticCollect += CheckAchievement;
			}
		}
		
		private void SetSavedPointsValue(int savedPointsValue)
		{
			this.savedPointsValue = savedPointsValue;
		}

		private void CheckAchievement(int pointsValue)
		{
			if (savedPointsValue + pointsValue >= this.pointsValue)
			{
				achievementSystem.Unlock(achievement);
				Player.PointController.OnStaticCollect -= CheckAchievement;
			}
			achievementSystem.SaveProgress(achievement, 
				savedPointsValue + pointsValue);
		}
	}
}