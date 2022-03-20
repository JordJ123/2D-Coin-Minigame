using UnityEngine;

namespace Achievement.Death
{
	public class DeathTotalController : AchievementController
	{
		[SerializeField] private int deathCount;
		private int currentDeathCount;
		
		private void Awake()
		{
			achievement = new Achievement("Total Deaths", "Elder Ring", 
				string.Format("Experience {0} deaths in total", deathCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentDeathCount(
					(int) achievementSystem.GetProgress(achievement));
				Player.TriggerDetector.OnDeath += CheckAchievement;
			}
		}

		private void SetCurrentDeathCount(int currentDeathCount)
		{
			this.currentDeathCount = currentDeathCount;
		}

		private void CheckAchievement()
		{
			currentDeathCount++;
			if (currentDeathCount >= deathCount)
			{
				achievementSystem.Unlock(achievement);
				Player.TriggerDetector.OnDeath -= CheckAchievement;
			}
			achievementSystem.SaveProgress(achievement, currentDeathCount);
		}
	}
}