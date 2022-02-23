using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LivesController))]
[RequireComponent(typeof(PointController))]
[RequireComponent(typeof(PowerUpController))]
[RequireComponent(typeof(Player.SpawnController))]
public class TriggerDetector : MonoBehaviour
{
    private LivesController livesController;
    private PointController pointController;
    private PowerUpController powerUpController;
    private Player.SpawnController spawnController;
    private GameObject gameObj;
    
    private void Awake()
    {
        livesController = GetComponent<LivesController>();
        pointController = GetComponent<PointController>();
        powerUpController = GetComponent<PowerUpController>();
        spawnController = GetComponent<Player.SpawnController>();
        gameObj = gameObject;
    }
    
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Enemy")
        {
            if (powerUpController.HasSword())
            {
                collider.transform.parent.gameObject.GetComponent<Enemy.SpawnController>().Despawn();
            }
            else
            {
                livesController.LoseLife();
                spawnController.Respawn();
            }
        }
        else if (collider.tag == "Point")
        {
            collider.GetComponent<Point.SpawnController>().Despawn();
            pointController.CollectPoints(
                collider.GetComponent<ValueController>().GetValue());
        }
        else if (collider.tag == "PowerUp")
        {
            collider.GetComponent<PowerUp.SpawnController>().Despawn();
            collider.GetComponent<AbilityController>().Ability(gameObj);
        }
    }
}
