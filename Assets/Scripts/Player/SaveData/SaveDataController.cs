using System.Collections;
using System.Collections.Generic;
using Player.SaveData;
using UnityEngine;

public class SaveDataController : MonoBehaviour
{
	[SerializeField] private string profileName;
	[SerializeField] private Color achievementColour;
	[SerializeField] private bool resetAchievementData;
	private Manager.AchievementManager achievementManager;
	private AchievementData achievementData;
	
	
	private void Awake()
	{
		achievementManager = FindObjectOfType<Manager.AchievementManager>();
		SaveData saveData = SaveData.Load(profileName + "/achievements");
		if (saveData != null && !resetAchievementData)
		{
			achievementData = (AchievementData) saveData;
		}
		else
		{
			achievementData = new AchievementData(profileName);
		}
	}

	public Color GetAchievementColour()
	{
		return achievementColour;
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
}
