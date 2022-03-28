using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player {
    [RequireComponent(typeof(LivesController))]
    [RequireComponent(typeof(Player.PointController))]
    [RequireComponent(typeof(PowerUpController))]
    [RequireComponent(typeof(Player.SpawnController))]
    public class TriggerDetector : MonoBehaviour
	{
		public static event Action OnStaticDeath;
		public static event Action OnKill;

		[SerializeField] private UnityEvent OnInvulnerability;
		[SerializeField] private UnityEvent OnVulnerability;
		[SerializeField] private int invulnerabilityDuration;
		
        private LivesController livesController;
        private Player.PointController pointController;
        private PowerUpController powerUpController;
        private Player.SpawnController spawnController;
        private GameObject gameObj;

		private Enemy.HealthController enemyHealthController;
		private bool ignoreEnemies;
        
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
            if (!ignoreEnemies && collider.tag == "Enemy")
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
						if (!livesController.LoseLife())
						{
							spawnController.Respawn();
							StartCoroutine(Invulnerability());
						};
						OnStaticDeath?.Invoke();
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

		private IEnumerator Invulnerability()
		{
			ignoreEnemies = true;
			OnInvulnerability?.Invoke();
			yield return new WaitForSeconds(invulnerabilityDuration);
			ignoreEnemies = false;
			OnVulnerability?.Invoke();
		}
    }
}

