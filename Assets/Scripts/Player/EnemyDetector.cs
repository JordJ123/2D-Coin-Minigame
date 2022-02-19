using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LivesController))]
[RequireComponent(typeof(Player.SpawnController))]
public class EnemyDetector : MonoBehaviour
{
    private LivesController livesController;
    private Player.SpawnController spawnController;
    
    private void Awake()
    {
        livesController = GetComponent<LivesController>();
        spawnController = GetComponent<Player.SpawnController>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Enemy")
        {
            livesController.LoseLife();
            spawnController.Respawn();
        }
    }
}
