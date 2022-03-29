using UnityEngine;

namespace Player.Achievement.Life
{
	public class LifeSmallController : AchievementController
	{
		[SerializeField] private int livesCount;
		private LivesController livesController;
		private int currentLifeCount;
		
		private void Awake()
		{
			livesController = transform.parent.GetComponent<LivesController>();
			achievement = new Achievement("Small Lives", 
				"Knight in Shining Armor",
				string.Format("Gain {0} lives in one game", livesCount), 
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				livesController.OnGain.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int ignore)
		{
			currentLifeCount++;
			if (currentLifeCount >= livesCount)
			{
				saveDataController.UnlockAchievement(achievement);
				livesController.OnGain.RemoveListener(CheckAchievement);
			}
		}
	}
}