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
    
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Point")
        {
            collider.GetComponent <Point.SpawnController>().Despawn();
            pointsCollected++;
            if (pointsCollected % pointsCounter == 0)
            {
                foreach (var point in points)
                {
                    point.GetComponent<Point.SpawnController>().Respawn();
                }
            }
        }
    }
}
