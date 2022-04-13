using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Achievement
{
	public abstract class AchievementController : MonoBehaviour
	{
		protected AchievementListController achievementListController;
		protected SaveDataController saveDataController;
		protected Achievement achievement;

		protected void Awake()
		{
			achievementListController = transform.parent
				.GetComponent<AchievementListController>();
			saveDataController = transform.parent
				.GetComponent<SaveDataController>();
		}

		protected void Start()
		{
			if (saveDataController.IsAchievementUnlocked(achievement))
			{
				achievement.Unlock();
			}
		}
	}
}