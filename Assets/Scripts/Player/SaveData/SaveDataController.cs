using System.Collections;
using System.Collections.Generic;
using Player;
using Player.SaveData;
using UnityEngine;

[RequireComponent(typeof(SpawnController))]
[RequireComponent(typeof(TriggerDetector))]
public class SaveDataController : MonoBehaviour
{
	[SerializeField] private string profileName;
	[SerializeField] private bool isPlayerOne;
	[SerializeField] private bool resetAchievementData;
	[SerializeField] private bool resetStatisticsData;
	private Manager.AchievementManager achievementManager;
	private LivesController livesController;
	private MovementController movementController;
	private PointController pointController;
	private TriggerDetector triggerDetector;
	private AchievementData achievementData;
	private StatisticsData statisticsData;
	private float distanceCurrentX;
	private float distanceCurrentY;
	
	private void Awake()
	{
		achievementManager = FindObjectOfType<Manager.AchievementManager>();
		livesController = GetComponent<LivesController>();
		movementController = GetComponent<MovementController>();
		pointController = GetComponent<PointController>();
		triggerDetector = GetComponent<TriggerDetector>();
		if (isPlayerOne)
		{
			if (ModeSelectController.GetPlayerOneName() != "")
			{
				profileName = ModeSelectController.GetPlayerOneName();
			}
		}
		else
		{
			if (ModeSelectController.GetPlayerTwoName() != "")
			{
				profileName = ModeSelectController.GetPlayerTwoName();
			}
		}
		SaveData saveData = SaveData.Load(profileName + "/achievements");
		if (saveData != null && !resetAchievementData)
		{
			achievementData = (AchievementData) saveData;
		}
		else
		{
			achievementData = new AchievementData(profileName);
		}
		saveData = SaveData.Load(profileName + "/statistics");
		if (saveData != null && !resetStatisticsData)
		{
			statisticsData = (StatisticsData) saveData;
		}
		else
		{
			statisticsData = new StatisticsData(profileName);
		}
	}

	private void Start()
	{
		distanceCurrentX = GetComponent<SpawnController>().GetSpawnX();
		distanceCurrentY = GetComponent<SpawnController>().GetSpawnY();
		triggerDetector.OnDeath.AddListener(statisticsData.IncrementDeaths);
		movementController.OnMove.AddListener(IncrementDistance);
		triggerDetector.OnKill.AddListener(statisticsData.IncrementKills);
		livesController.OnGain.AddListener(statisticsData.IncrementLives);
		pointController.OnCollect.AddListener(statisticsData.IncrementPoints);
	}

	public bool IsAchievementUnlocked(
		Player.Achievement.Achievement achievement)
	{
		return achievementData.HasAchievement(achievement);
	}
	
	public float GetAchievementProgress(
		Player.Achievement.Achievement achievement)
	{
		return achievementData.GetProgress(achievement);
	}
	
	public void SaveAchievementProgress(
		Player.Achievement.Achievement achievement, float data)
	{
		achievementData.SaveProgress(achievement, data);
	}
	
	public void UnlockAchievement(
		Player.Achievement.Achievement achievement)
	{
		achievement.Unlock();
		achievementData.UnlockAchievement(achievement);
		achievementManager.EnqueueAchievement(achievement);
	}

	private void IncrementDistance(bool ignore, Transform transform)
	{
		statisticsData.IncrementDistance(transform, distanceCurrentX, 
			distanceCurrentY);
		distanceCurrentX = transform.position.x;
		distanceCurrentY = - transform.position.y;
	}
}
