using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointLargeController : AchievementController
	{
		private PointController pointController;
		
		private void Awake()
		{
			pointController = transform.parent.GetComponent<PointController>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("Large Points");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				pointController.OnCollect.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= achievementListController.pointsLargeValue)
			{
				saveDataController.UnlockAchievement(achievement);
				pointController.OnCollect.RemoveListener(CheckAchievement);
			}
		}
	}
}