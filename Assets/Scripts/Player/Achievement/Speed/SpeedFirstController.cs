using UnityEngine;

namespace Player.Achievement.Speed
{
	public class SpeedFirstController : AchievementController
	{
		private MovementController movementController;
		
		private void Awake()
		{
			movementController =
				transform.parent.GetComponent<MovementController>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("First Speed Movement");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				movementController.OnMove.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(bool hasSpeedPowerUp, Transform ignore)
		{
			if (hasSpeedPowerUp)
			{
				saveDataController.UnlockAchievement(achievement);
				movementController.OnMove.RemoveListener(CheckAchievement);
			}
		}
	}
}