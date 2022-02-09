using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Point Objects
public class CollectController : MonoBehaviour
{
    private GameObject gameObj;
    
    private void Awake()
    {
        gameObj = gameObject;
    }
    
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Player") 
        {
            Destroy(gameObj);
        }
    }
}
