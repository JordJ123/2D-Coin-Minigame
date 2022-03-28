using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player {
    public class PointController : MonoBehaviour
	{
		[SerializeField] private UnityEvent<int> OnCollect;
        [SerializeField] private int pointsValue;
		
		public static event Action<int> OnStaticCollect;
		private GameObject[] points;
		private int pointsCollected;
        private int pointsCounter;
        
        private void Awake()
        {
            points = GameObject.FindGameObjectsWithTag("Point");
			pointsCounter = points.Length;
        }

		private void Start()
		{
			OnStaticCollect?.Invoke(pointsValue);
			OnCollect?.Invoke(pointsValue);
		}
        
        public void CollectPoints(int value) 
        {
            pointsValue += value;
            pointsCollected++;
			OnStaticCollect?.Invoke(pointsValue);
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

