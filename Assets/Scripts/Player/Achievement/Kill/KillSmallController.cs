using UnityEngine;

namespace Player.Achievement.Kill
{
	public class KillSmallController : AchievementController
	{
		[SerializeField] private int killCount;
		private TriggerDetector triggerDetector;
		private int currentKillCount;
		
		private void Awake()
		{
			triggerDetector = transform.parent.GetComponent<TriggerDetector>();
			achievement = new Achievement("Small Kills", "Commander",
				string.Format("Kill {0} enemies in one game", killCount), 
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				triggerDetector.OnKill.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement()
		{
			currentKillCount++;
			if (currentKillCount >= killCount)
			{
				saveDataController.UnlockAchievement(achievement);
				triggerDetector.OnKill.RemoveListener(CheckAchievement);
			}
			
		}
	}
}