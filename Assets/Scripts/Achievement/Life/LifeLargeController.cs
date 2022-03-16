using UnityEngine;

namespace Achievement.Death
{
	public class LifeLargeController : AchievementController
	{
		[SerializeField] private int livesCount;
		private int currentLifeCount;
		
		private void Awake()
		{
			base.Awake();
			achievement = new Achievement("Large Lives",
				string.Format("Gain {0} lives in one game", livesCount));
		}
		
		private void Start()
		{
			if (!achievement.IsUnlocked())
			{
				Player.LivesController.OnGain += CheckAchievement;
			}
		}

		private void CheckAchievement(int ignore)
		{
			currentLifeCount++;
			if (currentLifeCount >= livesCount)
			{
				achievementSystem.Unlock(achievement);
				Player.LivesController.OnGain -= CheckAchievement;
			}
		}
	}
}