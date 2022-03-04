using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    private GameObject[] points;
    private int pointsValue;
    private int pointsCollected;
    private int pointsCounter;
    
    
    private void Awake()
    {
        points = GameObject.FindGameObjectsWithTag("Point");
        pointsCounter = points.Length;
    }
    
    public void CollectPoints(int value) 
    {
        pointsValue += value;
        pointsCollected++;
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
