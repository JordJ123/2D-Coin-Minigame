using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
	public class PowerUpController : MonoBehaviour
	{
		[SerializeField] public UnityEvent OnLives;
		[SerializeField] public UnityEvent OnAttack;
		[SerializeField] public UnityEvent OnAttackReset;
		[SerializeField] public UnityEvent OnSpeed;
		[SerializeField] public UnityEvent OnSpeedReset;
		[SerializeField] private UnityEvent<int> OnSecond;
		[SerializeField] private Color attackColour;
		private GameObject gameObj;
		private PowerUp.TimedAbilityController powerUpController;
		private Enemy.SpriteController[] enemies;

		private void Awake()
		{
			enemies = FindObjectsOfType<Enemy.SpriteController>();
		}

	    public void SetAttackPowerUp(PowerUp.AttackAbilityController
			attackAbilityController)
		{
			RemovePowerUp();
			OnAttack?.Invoke();
			foreach (var enemy in enemies)
			{
				enemy.SetVunerable(attackColour);
			}
			powerUpController = attackAbilityController;
		}

	    public void SetLivesPowerUp()
	    {
			OnLives?.Invoke();
		}
		
		public void SetSpeedPowerUp(PowerUp.SpeedAbilityController 
			speedAbilityController)
		{
			RemovePowerUp();
			OnSpeed?.Invoke();
			powerUpController = speedAbilityController;
		}
		
		public void RemovePowerUp()
		{
			if (powerUpController != null)
			{
				StopAllCoroutines();
				OnSecondEvent(0);
				if (HasAttackPowerUp())
				{
					foreach (var enemy in enemies)
					{
						enemy.SetInvunerable(attackColour);
					}
					OnAttackReset?.Invoke();
				} 
				else if (HasSpeedPowerUp())
				{
					OnSpeedReset?.Invoke();
				}
				powerUpController = null;
			}
		}

		public bool HasAttackPowerUp()
		{
			if (powerUpController != null)
			{
				return powerUpController.GetType() == 
					typeof(PowerUp.AttackAbilityController);
			}
			return false;
		}
		
		public bool HasSpeedPowerUp()
		{
			if (powerUpController != null)
			{
				return powerUpController.GetType() == 
					typeof(PowerUp.SpeedAbilityController);
			}
			return false;
		}

		public void OnSecondEvent(int duration)
		{
			OnSecond?.Invoke(duration);
		}
	}
}
