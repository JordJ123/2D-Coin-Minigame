using System;
using UnityEngine;

namespace Player.Achievement.Speed
{
	public class SpeedTotalController : AchievementController
	{
		[SerializeField] private float distanceCount;
		private MovementController movementController;
		private float distanceCurrentCount;
		private float distanceCurrentX;
		private float distanceCurrentY;
		
		private void Awake()
		{
			movementController =
				transform.parent.GetComponent<MovementController>();
			achievement = new Achievement("Total Speed Movement", 
				"The Knights of Run", string.Format(
				"Move with the speed power-up a distance of {0} in total", 
				distanceCount), transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentDistanceCount(
					saveDataController.GetAchievementProgress(achievement));
				distanceCurrentX = transform.parent
					.GetComponent<SpawnController>().GetSpawnX();
				distanceCurrentY= transform.parent
					.GetComponent<SpawnController>().GetSpawnY();
				movementController.OnMove.AddListener(CheckAchievement);
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
				if (distanceCurrentCount >= distanceCount)
				{
					saveDataController.UnlockAchievement(achievement);
					movementController.OnMove.RemoveListener(CheckAchievement);
				}
				saveDataController.SaveAchievementProgress(
					achievement, distanceCurrentCount);
			}
			distanceCurrentX = transform.position.x;
			distanceCurrentY = - transform.position.y;
		}
	}
}