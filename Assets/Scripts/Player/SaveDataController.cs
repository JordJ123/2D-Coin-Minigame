using System.Collections;
using System.Collections.Generic;
using Achievement;
using SaveData;
using UnityEngine;

public class SaveDataController : MonoBehaviour
{
	[SerializeField] private bool resetAchievementData;
	private Manager.AchievementManager achievementManager;
	private AchievementData achievementData;
	
	private void Awake()
	{
		achievementManager = FindObjectOfType<Manager.AchievementManager>();
		SaveData.SaveData saveData = SaveDataSystem.Load("achievements");
		if (saveData != null && !resetAchievementData)
		{
			achievementData = (AchievementData) saveData;
		}
		else
		{
			achievementData = new AchievementData("achievements");
		}
	}
	
	public bool IsAchievementUnlocked(Achievement.Achievement achievement)
	{
		return achievementData.HasAchievement(achievement);
	}
	
	public float GetAchievementProgress(Achievement.Achievement achievement)
	{
		return achievementData.GetProgress(achievement);
	}
	
	public void SaveAchievementProgress(Achievement.Achievement achievement, 
		float data)
	{
		achievementData.SaveProgress(achievement, data);
	}
	
	public void UnlockAchivement(Achievement.Achievement achievement)
	{
		achievement.Unlock();
		achievementData.UnlockAchievement(achievement);
		achievementManager.EnqueueAchievement(achievement);
	}
}
