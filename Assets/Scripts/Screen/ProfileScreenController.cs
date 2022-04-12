using System.Collections;
using System.Collections.Generic;
using Player.SaveData;
using UnityEngine;
using UnityEngine.Events;

public class ProfileScreenController : MonoBehaviour
{
	[SerializeField] private UnityEvent<float> OnDeaths;
	[SerializeField] private UnityEvent<float> OnDistance;
	[SerializeField] private UnityEvent<float> OnKills;
	[SerializeField] private UnityEvent<float> OnLives;
	[SerializeField] private UnityEvent<float> OnPoints;
	private StatisticsData statisticsData;
	
    private void Start()
	{
		string profileName = ProfileSelectController.profileNameSelected;
		if (profileName == null)
		{
			profileName = "PlayerOne";
		}
		Debug.Log(profileName);
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
}
