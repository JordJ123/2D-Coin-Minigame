using UnityEngine;

namespace Achievement.Life
{
	public class LifeTotalController : AchievementController
	{
		[SerializeField] private int livesCount;
		private int currentLifeCount;
		
		private void Awake()
		{
			achievement = new Achievement("Total Lives", "The Dark Knight",
				string.Format("Gain {0} lives in total", livesCount));
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentLifeCount(
					(int) achievementSystem.GetProgress(achievement));
				Player.LivesController.OnGain += CheckAchievement;
			}
		}
		
		private void SetCurrentLifeCount(int currentLifeCount)
		{
			this.currentLifeCount = currentLifeCount;
		}

		private void CheckAchievement(int ignore)
		{
			currentLifeCount++;
			if (currentLifeCount >= livesCount)
			{
				achievementSystem.Unlock(achievement);
				Player.LivesController.OnGain -= CheckAchievement;
			}
			achievementSystem.SaveProgress(achievement, currentLifeCount);
		}
	}
}