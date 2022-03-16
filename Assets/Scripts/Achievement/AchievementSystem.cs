using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achievement
{
	public class AchievementSystem : MonoBehaviour
	{
		[SerializeField] private UI.AchievementController achievementController;
		[SerializeField] private float achievementDisplayDuration;
		[SerializeField] private float achievementGapDuration;
		
		private Queue<Achievement> achievementQueue = new Queue<Achievement>();

		private void Awake()
		{
			StartCoroutine(DisplayAchievement());
		}

		public void Unlock(Achievement achievement)
		{
			achievement.Unlock();
			achievementQueue.Enqueue(achievement);
		}

		private IEnumerator DisplayAchievement()
		{
			while (true)
			{
				if (achievementQueue.Count > 0)
				{
					achievementController.DisplayAchievement(
						achievementQueue.Dequeue());
					yield return new WaitForSeconds(achievementDisplayDuration);
					achievementController.RemoveAchievement();
					yield return new WaitForSeconds(1f);
				}
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
