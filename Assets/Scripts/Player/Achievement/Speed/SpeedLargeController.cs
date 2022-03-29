using System;
using Point;
using UnityEngine;

namespace Player.Achievement.Speed
{
	public class SpeedLargeController : AchievementController
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
			achievement = new Achievement("Large Speed Movement", 
				"Diogoooooooooo Jota!!!", string.Format(
				"Move with the speed power-up a distance of {0} in one game", 
				distanceCount), transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
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
				if (distanceCurrentCount >= distanceCount)
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