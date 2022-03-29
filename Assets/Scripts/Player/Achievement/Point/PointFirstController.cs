using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointFirstController : AchievementController
	{
		private PointController pointController;
		
		private void Awake()
		{
			pointController = transform.parent.GetComponent<PointController>();
			achievement = new Achievement("First Point", "Peasant",
				"Collect your first point", transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
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