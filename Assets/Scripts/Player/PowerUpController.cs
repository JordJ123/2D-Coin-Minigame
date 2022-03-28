using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player.SpriteController))]
public class PowerUpController : MonoBehaviour
{
	[SerializeField] private UnityEvent<int> OnSecond;
	[SerializeField] private Color attackColour;
	
	public static event Action OnAttackReset;
	public static event Action OnSpeedReset;
	private GameObject gameObj;
    private Player.LivesController livesController;
    private Player.SpriteController spriteController;
    private PowerUp.TimedAbilityController powerUpController;
	private Enemy.SpriteController[] enemies;

	private void Awake()
	{
		enemies = FindObjectsOfType<Enemy.SpriteController>();
		livesController = GetComponent<Player.LivesController>();
        spriteController = GetComponent<Player.SpriteController>();
	}

    public void SetAttackPowerUp(PowerUp.AttackAbilityController
		attackAbilityController)
	{
		RemovePowerUp();
		spriteController.SetAttackPowerUp();
		foreach (var enemy in enemies)
		{
			enemy.SetVunerable(attackColour);
		}
		powerUpController = attackAbilityController;
	}

    public void SetLivesPowerUp()
    {
        livesController.GainLife();
    }
	
	public void SetSpeedPowerUp(PowerUp.SpeedAbilityController 
		speedAbilityController)
	{
		RemovePowerUp();
		spriteController.SetSpeedPowerUp();
		powerUpController = speedAbilityController;
	}
	
	public void RemovePowerUp()
	{
		if (powerUpController != null)
		{
			StopAllCoroutines();
			OnSecondEvent(0);
			spriteController.SetNormal();
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
