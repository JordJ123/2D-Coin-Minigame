using UnityEngine;

namespace Player.Achievement.Death
{
	public class DeathTotalController : AchievementController
	{
		[SerializeField] private int deathCount;
		private TriggerDetector triggerDetector;
		private int currentDeathCount;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("Total Deaths", "Elder Ring", 
				string.Format("Experience {0} deaths in total", deathCount), 
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				SetCurrentDeathCount((int) saveDataController
					.GetAchievementProgress(achievement));
				triggerDetector.OnDeath.AddListener(CheckAchievement);
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
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnDeath.RemoveListener(CheckAchievement);
			}
			saveDataController.SaveAchievementProgress(
				achievement, currentDeathCount);
		}
	}
}