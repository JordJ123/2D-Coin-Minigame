using System;
using Point;
using UnityEngine;

namespace Player.Achievement.Speed
{
	public class SpeedLargeController : AchievementController
	{
		private MovementController movementController;
		private float distanceCurrentCount;
		private float distanceCurrentX;
		private float distanceCurrentY;
		
		private void Awake()
		{
			movementController =
				transform.parent.GetComponent<MovementController>();
			base.Awake();
		}
		
		private void Start()
		{
			achievement 
				= achievementListController.GetAchievement("Large Speed Movement");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				distanceCurrentX = transform.parent
					.GetComponent<SpawnController>().GetSpawnX();
				distanceCurrentY= transform.parent
					.GetComponent<SpawnController>().GetSpawnY();
				movementController.OnMove.AddListener(CheckAchievement);
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
					>= achievementListController.speedLargeCount)
				{
					saveDataController.UnlockAchievement(achievement);
					movementController.OnMove.RemoveListener(CheckAchievement);
				}

			}
			distanceCurrentX = transform.position.x;
			distanceCurrentY = - transform.position.y;
		}
	}
}