using System;
using Point;
using UnityEngine;

namespace Player.Achievement.Speed
{
	public class SpeedOnePowerUpController : AchievementController
	{
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
			base.Awake();
		}
		
		private void Start()
		{
			achievement = achievementListController
				.GetAchievement("One Power-Up Speed Movement");
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
				if (distanceCurrentCount 
					>= achievementListController.speedOnePowerUpCount)
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