using System;
using System.Collections;
using System.Collections.Generic;
using SaveData;
using UnityEngine;

namespace Achievement
{
	public class AchievementSystem : MonoBehaviour
	{
		[SerializeField] private float achievementDisplayDuration;
		[SerializeField] private float achievementGapDuration;
		[SerializeField] private bool resetData;

		public static event Action<Achievement> OnDisplay;
		public static event Action OnRemove;
		private Queue<Achievement> achievementQueue = new Queue<Achievement>();
		private AchievementData achievementData;
		
		private void Awake()
		{
			SaveData.SaveData saveData = SaveDataSystem.Load("achievements");
			if (saveData != null && !resetData)
			{
				achievementData = (AchievementData) saveData;
			}
			else
			{
				achievementData = new AchievementData("achievements");
			}
			StartCoroutine(DisplayAchievement());
		}

		public bool IsUnlocked(Achievement achievement)
		{
			return achievementData.HasAchievement(achievement);
		}

		public void Unlock(Achievement achievement)
		{
			achievement.Unlock();
			achievementData.UnlockAchievement(achievement);
			achievementQueue.Enqueue(achievement);
		}

		private IEnumerator DisplayAchievement()
		{
			while (true)
			{
				if (achievementQueue.Count > 0)
				{
					OnDisplay?.Invoke(achievementQueue.Dequeue());
					yield return new WaitForSeconds(achievementDisplayDuration);
					OnRemove?.Invoke();
					yield return new WaitForSeconds(1f);
				}
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
