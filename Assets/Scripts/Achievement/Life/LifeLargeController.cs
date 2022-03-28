using UnityEngine;

namespace Achievement.Life
{
	public class LifeLargeController : AchievementController
	{
		[SerializeField] private int livesCount;
		private int currentLifeCount;
		
		private void Awake()
		{
			achievement = new Achievement("Large Lives", 
				"Marvelous Black Knight",
				string.Format("Gain {0} lives in one game", livesCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				Player.LivesController.OnStaticGain += CheckAchievement;
			}
		}

		private void CheckAchievement(int ignore)
		{
			currentLifeCount++;
			if (currentLifeCount >= livesCount)
			{
				achievementSystem.Unlock(achievement);
				Player.LivesController.OnStaticGain -= CheckAchievement;
			}
		}
	}
}