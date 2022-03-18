using System;
using Point;
using UnityEngine;

namespace Achievement.Speed
{
	public class SpeedSmallController : AchievementController
	{
		[SerializeField] private float distanceCount;
		private float distanceCurrentCount;
		private float distanceCurrentX;
		private float distanceCurrentY;
		
		private void Awake()
		{
			achievement = new Achievement("Small Speed Movement", string.Format(
				"Move with the speed power-up a distance of {0} in one game", 
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
				}

			}
			distanceCurrentX = transform.position.x;
			distanceCurrentY = - transform.position.y;
		}
	}
}