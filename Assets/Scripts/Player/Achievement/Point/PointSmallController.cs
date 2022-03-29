using UnityEngine;

namespace Player.Achievement.Point
{
	public class PointSmallController : AchievementController
	{
		[SerializeField] private int pointsValue;
		private PointController pointController;
		
		private void Awake()
		{
			pointController = transform.parent.GetComponent<PointController>();
			achievement = new Achievement("Small Points", "Noble",
				string.Format("Collect {0} points in one game", pointsValue),
				transform.parent.GetComponent<SaveDataController>()
					.GetAchievementColour());
			base.Awake();
		}
		
		private void Start()
		{
			base.Start();
			if (!achievement.IsUnlocked())
			{
				pointController.OnCollect.AddListener(CheckAchievement);
			}
		}

		private void CheckAchievement(int pointsValue)
		{
			if (pointsValue >= this.pointsValue)
			{
				saveDataController.UnlockAchievement(achievement);
				pointController.OnCollect.RemoveListener(CheckAchievement);
			}
		}
	}
}