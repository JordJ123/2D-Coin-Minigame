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
		[SerializeField] public UnityEvent OnDeath;
		[SerializeField] public UnityEvent OnKill;
		[SerializeField] private UnityEvent<int> OnPoint;
		[SerializeField] private UnityEvent OnInvulnerability;
		[SerializeField] private UnityEvent OnVulnerability;
		[SerializeField] private int invulnerabilityDuration;
		
        private LivesController livesController;
		private PowerUpController powerUpController;
		private GameObject gameObj;

		private Enemy.HealthController enemyHealthController;

		private void Awake()
        {
            livesController = GetComponent<LivesController>();
            powerUpController = GetComponent<PowerUpController>();
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
						if (!livesController.LoseLife())
						{
							OnDeath?.Invoke();
							StartCoroutine(Invulnerability());
						};
					}
				}
				enemyHealthController = null;
			}
            else if (collider.tag == "Point")
            {
                collider.GetComponent<Point.SpawnController>().Despawn();
                OnPoint?.Invoke(
					collider.GetComponent<ValueController>().GetValue());
			}
            else if (collider.tag == "PowerUp")
            {
				collider.GetComponent<PowerUp.AbilityController>()
					.Ability(gameObj);
			}
        }

		private IEnumerator Invulnerability()
		{
			gameObj.layer = 14;
			OnInvulnerability?.Invoke();
			yield return new WaitForSeconds(invulnerabilityDuration);
			gameObj.layer = 6;
			OnVulnerability?.Invoke();
		}
    }
}

