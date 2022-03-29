using UnityEngine;

namespace Player.Achievement.Death
{
	public class DeathLargeController : AchievementController
	{
		[SerializeField] private int deathCount;
		private TriggerDetector triggerDetector;
		private int currentDeathCount;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("large Deaths", "Fus Ro Die",
				string.Format("Experience {0} deaths in one game", deathCount), 
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnDeath.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentDeathCount++;
			if (currentDeathCount >= deathCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnDeath.RemoveListener(CheckAchievement);
			}
		}
	}
}