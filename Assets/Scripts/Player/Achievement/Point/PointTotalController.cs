using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointTotalController : AchievementController
	{
		private PointController pointController;
		private int savedPointsValue;
		
		private void Awake()
		{
			pointController = transform.parent.GetComponent<PointController>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("Total Points");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetSavedPointsValue((int) saveDataController
					.GetAchievementProgress(achievement));
				pointController.OnCollect.AddListener(CheckAchievement);
			}
		}
		
		private void SetSavedPointsValue(int savedPointsValue)
		{
			this.savedPointsValue = savedPointsValue;
		}

		private void CheckAchievement(int pointsValue)
		{
			if (savedPointsValue + pointsValue 
				>= achievementListController.pointsTotalValue)
			{
				saveDataController.UnlockAchievement(achievement);
				pointController.OnCollect.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(achievement, 
				savedPointsValue + pointsValue);
		}
	}
}