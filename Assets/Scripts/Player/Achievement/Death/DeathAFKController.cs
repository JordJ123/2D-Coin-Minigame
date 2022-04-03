﻿using UnityEngine;

namespace Player.Achievement.Death
{
	public class DeathAFKController : AchievementController
	{
		private MovementController movementController;
		private TriggerDetector triggerDetector;
		private bool isFailed;
		
		private void Awake()
		{
			movementController = transform.parent.GetComponent<MovementController>();
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("AFK Death", "AFKnight",
				"Die without moving", transform.parent
					.GetComponent<SaveDataController>().GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				movementController.OnMove.AddListener(FailAchievement);
				triggerDetector.OnDeath.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			if (!isFailed)
			{
				saveDataController.UnlockAchievement(achievement);
				movementController.OnMove.RemoveListener(FailAchievement);
				triggerDetector.OnDeath.RemoveListener(CheckAchievement);
			}
			else
			{
				isFailed = false;
				movementController.OnMove.AddListener(FailAchievement);
			}
		}

		private void FailAchievement(bool ignore, Transform ignore2)
		{
			isFailed = true;
			movementController.OnMove.RemoveListener(FailAchievement);
		}
	}
}