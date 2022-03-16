using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PointController : MonoBehaviour
    {
        [SerializeField] private int startingPointsValue;
		
		public static event Action<int> OnCollect;
		private GameObject[] points;
        private int pointsValue;
        private int pointsCollected;
        private int pointsCounter;
        
        private void Awake()
        {
            points = GameObject.FindGameObjectsWithTag("Point");
			pointsValue = startingPointsValue;
			pointsCounter = points.Length;
        }

		private void Start()
		{
			OnCollect?.Invoke(pointsValue);
		}
        
        public void CollectPoints(int value) 
        {
            pointsValue += value;
            pointsCollected++;
			OnCollect?.Invoke(pointsValue);
			if (pointsCollected % pointsCounter == 0)
            {
				foreach (var point in points)
                {
                    point.GetComponent<Point.SpawnController>().Respawn();
                    PowerUp.SpawnController.SpawnPowerUp();
                }
            }
        }
    }
}

