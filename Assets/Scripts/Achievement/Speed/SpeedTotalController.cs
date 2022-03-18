using System;
using UnityEngine;

namespace Achievement.Speed
{
	public class SpeedTotalController : AchievementController
	{
		[SerializeField] private float distanceCount;
		private float distanceCurrentCount;
		private float distanceCurrentX;
		private float distanceCurrentY;
		
		private void Awake()
		{
			achievement = new Achievement("Total Speed Movement", string.Format(
				"Move with the speed power-up a distance of {0} in total", 
				distanceCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentDistanceCount(
					achievementSystem.GetProgress(achievement));
				distanceCurrentX = 
					FindObjectOfType<Player.SpawnController>().GetSpawnX();
				distanceCurrentY = 
					FindObjectOfType<Player.SpawnController>().GetSpawnY();
				Player.MovementController.OnMove += CheckAchievement;
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
					achievementSystem.Unlock(achievement);
					Player.MovementController.OnMove -= CheckAchievement;
				}
				achievementSystem.SaveProgress(achievement, 
					distanceCurrentCount);
			}
			distanceCurrentX = transform.position.x;
			distanceCurrentY = - transform.position.y;
		}
	}
}