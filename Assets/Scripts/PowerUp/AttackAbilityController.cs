using System.Collections;
using UnityEngine;

namespace PowerUp
{
	public class AttackAbilityController : TimedAbilityController
	{
		public override void Ability(GameObject player)
		{
			Collect();
			AbilityStart(player);
			player.GetComponent<Player.PowerUpController>().StartCoroutine(
				AbilityEnd(player.GetComponent<Player.PowerUpController>()));
		}
    
        protected override void AbilityStart(GameObject player)
        {
			player.GetComponent<Player.PowerUpController>().
				SetAttackPowerUp(this);
		}
    	
    	protected override IEnumerator AbilityEnd(
			Player.PowerUpController playerPowerUpController)
    	{
			for (int currentDuration = duration; currentDuration > 0; 
				currentDuration--)
			{
				playerPowerUpController.OnSecondEvent(currentDuration);
				yield return new WaitForSeconds(1);
    		}
			playerPowerUpController.RemovePowerUp();
		}
    }
}
