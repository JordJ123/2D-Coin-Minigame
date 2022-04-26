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
				movementController.OnMoveSpeed.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			saveDataController.UnlockAchievement(achievement);
			movementController.OnMoveSpeed.RemoveListener(CheckAchievement);
		}
	}
}