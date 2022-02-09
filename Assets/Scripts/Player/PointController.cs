using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Player Objects
public class PointController : MonoBehaviour
{
    private int points = 0;
    
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Point") 
        {
            points++;
        }
    }
}
