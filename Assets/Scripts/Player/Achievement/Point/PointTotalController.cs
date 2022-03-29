using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointTotalController : AchievementController
	{
		[SerializeField] private int pointsValue;
		private PointController pointController;
		private int savedPointsValue;
		
		private void Awake()
		{
			pointController = transform.parent.GetComponent<PointController>();
			achievement = new Achievement("Total Points", 
				"The Lord of the Coins", 
				string.Format("Collect {0} points in total", pointsValue),
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
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
			if (savedPointsValue + pointsValue >= this.pointsValue)
			{
				saveDataController.UnlockAchievement(achievement);
				pointController.OnCollect.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(achievement, 
				savedPointsValue + pointsValue);
		}
	}
}