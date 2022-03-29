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
			achievement = new Achievement("First Speed Movement", "First Steps",
				"Move with the speed power-up for the first time", 
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
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