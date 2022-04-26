using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player {
    public class PointController : MonoBehaviour
	{
		[SerializeField] public UnityEvent<int> OnCollect;
		[SerializeField] private int pointsValue;
		private static GameObject[] points;
		private static int pointsLength;
		private static int pointsCollected;
		
        private void Awake()
        {
			if (points == null)
			{
				points = GameObject.FindGameObjectsWithTag("Point");
				pointsLength = points.Length;
			}
		}

		private void Start()
		{
			OnCollect?.Invoke(pointsValue);
		}

		public int GetPointsValue()
		{
			return pointsValue;
		}
        
        public void CollectPoints(int value) 
        {
            pointsValue += value;
			OnCollect?.Invoke(pointsValue);
			pointsCollected++;
			if (pointsCollected % pointsLength == 0)
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

