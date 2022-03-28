using System.Collections;
using UnityEngine;

namespace PowerUp
{
	public class AttackAbilityController : TimedAbilityController
	{
		private int id;

		public override void Ability(GameObject player)
		{
			AbilityStart(player);
			player.GetComponent<PowerUpController>().StartCoroutine(
				AbilityEnd(player.GetComponent<PowerUpController>()));
		}
    
        protected override void AbilityStart(GameObject player)
        {
			player.GetComponent<PowerUpController>().SetAttackPowerUp(this);
		}
    	
    	protected override IEnumerator AbilityEnd(
			PowerUpController playerPowerUpController)
    	{
			for (int currentDuration = duration; currentDuration > 0; 
				currentDuration--)
			{
				playerPowerUpController.OnSecondEvent(currentDuration);
				yield return new WaitForSeconds(1);
    		}
			playerPowerUpController.OnSecondEvent(0);
			playerPowerUpController.RemovePowerUp();
		}
    }
}
