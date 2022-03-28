using System.Collections;
using UnityEngine;

namespace PowerUp
{
	public class SpeedAbilityController : TimedAbilityController
	{
		public override void Ability(GameObject player)
		{
			AbilityStart(player);
			player.GetComponent<PowerUpController>().StartCoroutine(
				AbilityEnd(player.GetComponent<PowerUpController>()));
		}

		protected override void AbilityStart(GameObject player)
		{
			player.GetComponent<PowerUpController>().SetSpeedPowerUp(this);
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
			playerPowerUpController.RemovePowerUp();
		}
	}
}
