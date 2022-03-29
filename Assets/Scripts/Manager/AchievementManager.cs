using System;
using System.Collections;
using System.Collections.Generic;
using SaveData;
using UnityEngine;

namespace Manager
{
	public class AchievementManager : MonoBehaviour
	{
		[SerializeField] private float achievementDisplayDuration;
		[SerializeField] private float achievementGapDuration;

		public static event Action<Achievement.Achievement> OnDisplay;
		public static event Action OnRemove;
		private Queue<Achievement.Achievement> achievementQueue 
			= new Queue<Achievement.Achievement>();

		private void Awake()
		{
			StartCoroutine(DisplayAchievement());
		}

		public void EnqueueAchievement(Achievement.Achievement achievement)
		{
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
