using System;
using Point;
using UnityEngine;

namespace Achievement.Speed
{
	public class SpeedOnePowerUpController : AchievementController
	{
		[SerializeField] private float distanceCount;
		private float distanceCurrentCount;
		private float distanceCurrentX;
		private float distanceCurrentY;
		
		private void Awake()
		{
			achievement = new Achievement("One Power-Up Speed Movement", 
				string.Format("Move a distance of {0} within one speed power-up", 
				distanceCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				distanceCurrentX = 
					FindObjectOfType<Player.SpawnController>().GetSpawnX();
				distanceCurrentY = 
					FindObjectOfType<Player.SpawnController>().GetSpawnY();
				Player.MovementController.OnMove += CheckAchievement;
				PowerUpController.OnSpeedReset += FailAchievement;
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
					achievementSystem.Unlock(achievement);
					Player.MovementController.OnMove -= CheckAchievement;
					PowerUpController.OnSpeedReset += FailAchievement;
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