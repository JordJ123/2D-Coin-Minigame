using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Player Objects
public class PointController : MonoBehaviour
{
    private GameObject[] points;
    private int pointsCounter;
    private int pointsCollected = 0;
    
    private void Awake()
    {
        points = GameObject.FindGameObjectsWithTag("Point");
        pointsCounter = points.Length;
    }
    
    public void CollectPoints() 
    {
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
