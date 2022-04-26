using System;
using UnityEngine;

namespace Player.Achievement.Speed
{
	public class SpeedTotalController : AchievementController
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
			achievement = achievementListController
				.GetAchievement("Total Speed Movement");
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentDistanceCount(
					saveDataController.GetAchievementProgress(achievement));
				distanceCurrentX = transform.parent
					.GetComponent<SpawnController>().GetSpawnX();
				distanceCurrentY= transform.parent
					.GetComponent<SpawnController>().GetSpawnY();
				movementController.OnMoveSpeedDistance.AddListener(CheckAchievement);
			}
		}
		
		private void SetCurrentDistanceCount(float distanceCurrentCount)
		{
			this.distanceCurrentCount = distanceCurrentCount;
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
					>= achievementListController.speedTotalCount)
				{
					saveDataController.UnlockAchievement(achievement);
					movementController.OnMoveSpeedDistance.RemoveListener(CheckAchievement);
				}
				saveDataController.SaveAchievementProgress(
					achievement, distanceCurrentCount);
			}
			distanceCurrentX = transform.position.x;
			distanceCurrentY = - transform.position.y;
		}
	}
}