using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screen.GameScreen
{
	public class AchievementDisplayController : MonoBehaviour
	{
		[SerializeField] private float achievementDisplayDuration;
		[SerializeField] private float achievementGapDuration;

		public static event 
			Action<Player.Achievement.Achievement> OnDisplay;
		public static event Action OnRemove;
		private Queue<Player.Achievement.Achievement> achievementQueue 
			= new Queue<Player.Achievement.Achievement>();

		private void Awake()
		{
			StartCoroutine(DisplayAchievement());
		}

		public void EnqueueAchievement(
			Player.Achievement.Achievement achievement)
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
