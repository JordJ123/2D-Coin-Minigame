using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointFirstController : AchievementController
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
				= achievementListController.GetAchievement("First Point");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				pointController.OnCollect.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue > 0)
			{
				saveDataController.UnlockAchievement(achievement);
				pointController.OnCollect.RemoveListener(CheckAchievement);
			}
		}
	}	
}