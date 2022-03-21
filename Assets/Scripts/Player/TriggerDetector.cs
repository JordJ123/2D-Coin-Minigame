using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(LivesController))]
    [RequireComponent(typeof(Player.PointController))]
    [RequireComponent(typeof(PowerUpController))]
    [RequireComponent(typeof(Player.SpawnController))]
    public class TriggerDetector : MonoBehaviour
	{
		public static event Action OnDeath;
		public static event Action OnKill;
		
        private LivesController livesController;
        private Player.PointController pointController;
        private PowerUpController powerUpController;
        private Player.SpawnController spawnController;
        private GameObject gameObj;

		private Enemy.HealthController enemyHealthController;
        
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
				enemyHealthController
					= collider.GetComponent<Enemy.HealthController>();
				if (enemyHealthController.IsAlive())
				{
					if (powerUpController.HasAttackPowerUp())
					{
						enemyHealthController.Die();
						OnKill?.Invoke();
					}
					else
					{
						livesController.LoseLife();
						spawnController.Respawn();
						OnDeath?.Invoke();
					}
				}
				enemyHealthController = null;
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
                collider.GetComponent<PowerUp.IAbilityController>()
					.Ability(gameObj);
            }
        }
    }
}

