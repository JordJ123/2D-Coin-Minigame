using Player.Achievement;
using Player.SaveData;
using Screen.MenuScreen;
using UnityEngine;
using UnityEngine.Events;

namespace Screen
{
	[RequireComponent(typeof(AchievementListController))]
    public class ProfileScreenController : MonoBehaviour
    {
    	[SerializeField] private UnityEvent<float> OnDeaths;
    	[SerializeField] private UnityEvent<float> OnDistance;
    	[SerializeField] private UnityEvent<float> OnKills;
    	[SerializeField] private UnityEvent<float> OnLives;
    	[SerializeField] private UnityEvent<float> OnPoints;
    	[SerializeField] private UnityEvent<Achievement, string> OnAchievement;
    	private AchievementListController achievementListController;
    	private StatisticsData statisticsData;
    	private AchievementData achievementData;
    
    	private void Awake()
    	{
    		achievementListController = GetComponent<AchievementListController>();
    	}
    	
        private void Start()
    	{
    		string profileName = ProfileSelectController.profileNameSelected;
    		if (profileName == null)
    		{
    			profileName = "PlayerOne";
    		}
    		InitializeStatistics(profileName);
    		InitializeAchievements(profileName);
    	}
    
    	private void InitializeStatistics(string profileName)
    	{
    		SaveData saveData = SaveData.Load(profileName + "/statistics");
    		if (saveData != null)
    		{
    			statisticsData = (StatisticsData) saveData;
    		}
    		else
    		{
    			statisticsData = new StatisticsData(profileName);
    		}
    		OnDeaths?.Invoke(statisticsData.deaths);
    		OnDistance?.Invoke(statisticsData.distance);
    		OnKills?.Invoke(statisticsData.kills);
    		OnLives?.Invoke(statisticsData.lives);
    		OnPoints?.Invoke(statisticsData.points);
    	}
    
    	private void InitializeAchievements(string profileName)
    	{
    		SaveData saveData = SaveData.Load(profileName + "/achievements");
    		if (saveData != null)
    		{
    			achievementData = (AchievementData) saveData;
    		}
    		else
    		{
    			achievementData = new AchievementData(profileName);
    		}
    		foreach (var achievement 
				in achievementListController.GetAchievements())
    		{
    			if (achievementData.HasAchievement(achievement))
    			{
    				OnAchievement?.Invoke(achievement, "green");
    			}
    			else
    			{
    				OnAchievement?.Invoke(achievement, "red");
    			}
    		}
    	}
    }
}
