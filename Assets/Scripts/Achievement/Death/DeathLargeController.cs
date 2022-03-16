using UnityEngine;

namespace Achievement.Death
{
	public class DeathLargeController : AchievementController
	{
		[SerializeField] private int deathCount;
		private int currentDeathCount;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("Large Deaths",
				string.Format("Experience {0} deaths in one game", deathCount));
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.TriggerDetector.OnDeath += CheckAchievement;
			}
		}

		private void CheckAchievement()
		{
			currentDeathCount++;
			if (currentDeathCount >= deathCount)
			{
				achievementSystem.Unlock(achievement);
				Player.TriggerDetector.OnDeath -= CheckAchievement;
			}
		}
	}
}