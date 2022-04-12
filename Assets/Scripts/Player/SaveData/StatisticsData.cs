using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.SaveData {
	[Serializable]
    public class StatisticsData : SaveData
	{
		public int deaths { private set; get; }
		public float distance { private set; get; }
		public int kills { private set; get; }
		public int lives { private set; get; }
		public int points { private set; get; }

		public StatisticsData(string profileName)
			: base(profileName + "/statistics") {}

		public void IncrementDeaths()
		{
			deaths++;
			Save(this);
		}
		
		public void IncrementDistance(Transform transform, 
			float distanceCurrentX, float distanceCurrentY)
		{
			distance += Math.Abs(distanceCurrentX - transform.position.x);
			distance += Math.Abs(distanceCurrentY - transform.position.y);
			Save(this);
		}
		
		public void IncrementKills()
		{
			kills++;
			Save(this);
		}
		
		public void IncrementLives(int ignore)
		{
			lives++;
			Save(this);
		}

		public void IncrementPoints(int pointsValue)
		{
			points += pointsValue;
			Save(this);
		}
	}
}

