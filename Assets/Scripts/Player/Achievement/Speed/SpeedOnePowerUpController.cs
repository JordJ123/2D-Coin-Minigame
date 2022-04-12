using System;
using Point;
using UnityEngine;

namespace Player.Achievement.Speed
{
	public class SpeedOnePowerUpController : AchievementController
	{
		[SerializeField] private float distanceCount;
		private MovementController movementController;
		private PowerUpController powerUpController;
		private float distanceCurrentCount;
		private float distanceCurrentX;
		private float distanceCurrentY;
		
		private void Awake()
		{
			movementController =
				transform.parent.GetComponent<MovementController>();
			powerUpController =
				transform.parent.GetComponent<PowerUpController>();
			achievement = new Achievement("One Power-Up Speed Movement", 
				"Sonic and the Blue Knight", 
				string.Format("Move a distance of {0} within one speed power-up", 
				distanceCount), transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				distanceCurrentX = transform.parent
					.GetComponent<SpawnController>().GetSpawnX();
				distanceCurrentY= transform.parent
					.GetComponent<SpawnController>().GetSpawnY();
				movementController.OnMove.AddListener(CheckAchievement);
				powerUpController.OnSpeedReset.AddListener(FailAchievement);
			}
		}

		private void CheckAchievement(bool hasSpeedPowerUp, Transform transform)
		{
			if (hasSpeedPowerUp)
			{
				distanceCurrentCount += Math.Abs(distanceCurrentX 
					- transform.position.x);
				distanceCurrentCount += Math.Abs(distanceCurrentY 
					- transform.position.y);
				if (distanceCurrentCount >= distanceCount)
				{
					saveDataController.UnlockAchievement(achievement);
					movementController.OnMove.RemoveListener(CheckAchievement);
					powerUpController.OnSpeedReset
						.RemoveListener(FailAchievement);
				}

			}
			distanceCurrentX = transform.position.x;
			distanceCurrentY = - transform.position.y;
		}
		
		private void FailAchievement()
		{
			distanceCurrentCount = 0;
		}
	}
}