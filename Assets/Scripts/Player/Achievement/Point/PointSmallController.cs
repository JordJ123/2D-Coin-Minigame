using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointSmallController : AchievementController
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
				= achievementListController.GetAchievement("Small Points");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				pointController.OnCollect.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= achievementListController.pointsSmallValue)
			{
				saveDataController.UnlockAchievement(achievement);
				pointController.OnCollect.RemoveListener(CheckAchievement);
			}
		}
	}
}