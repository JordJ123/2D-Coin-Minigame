using UnityEngine;

namespace Achievement.Death
{
	public class DeathSmallController : AchievementController
	{
		[SerializeField] private int deathCount;
		private int currentDeathCount;
		
		private void Awake()
		{
			achievement = new Achievement("Small Deaths", 
				"Took a Zombie to the Knee",
				string.Format("Experience {0} deaths in one game", deathCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
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