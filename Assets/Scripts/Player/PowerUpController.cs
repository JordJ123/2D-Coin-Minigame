using System;
using UnityEngine;

[RequireComponent(typeof(Player.SpriteController))]
public class PowerUpController : MonoBehaviour
{
	public static event Action OnAttackReset;
	public static event Action OnSpeedReset;
	private GameObject gameObj;
    private Player.LivesController livesController;
    private Player.SpriteController spriteController;
    private PowerUp.TimedAbilityController powerUpController;

	private void Awake()
	{
		livesController = GetComponent<Player.LivesController>();
        spriteController = GetComponent<Player.SpriteController>();
	}

    public void SetAttackPowerUp(PowerUp.AttackAbilityController
		attackAbilityController)
	{
		RemovePowerUp();
		spriteController.SetAttackPowerUp();
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
			spriteController.SetNormal();
			if (HasAttackPowerUp())
			{
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
}
