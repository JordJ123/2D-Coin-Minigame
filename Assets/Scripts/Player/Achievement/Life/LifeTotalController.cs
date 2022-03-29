using UnityEngine;

namespace Player.Achievement.Life
{
	public class LifeTotalController : AchievementController
	{
		[SerializeField] private int livesCount;
		private LivesController livesController;
		private int currentLifeCount;
		
		private void Awake()
		{
			livesController = transform.parent.GetComponent<LivesController>();
			achievement = new Achievement("Total Lives", "The Dark Knight",
				string.Format("Gain {0} lives in total", livesCount), 
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentLifeCount((int) saveDataController
					.GetAchievementProgress(achievement));
				livesController.OnGain.AddListener(CheckAchievement);
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
				saveDataController.UnlockAchievement(achievement);
				livesController.OnGain.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(
				achievement, currentLifeCount);
		}
	}
}