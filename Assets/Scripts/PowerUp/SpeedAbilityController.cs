using System.Collections;
using UnityEngine;

namespace PowerUp
{
	public class SpeedAbilityController : TimedAbilityController
	{
		public override void Ability(GameObject player)
		{
			AbilityStart(player);
			player.GetComponent<PowerUpController>()
				.StartCoroutine(AbilityEnd(player));
		}

		protected override void AbilityStart(GameObject player)
		{
			player.GetComponent<PowerUpController>().SetSpeedPowerUp(this);
		}
	
		protected override IEnumerator AbilityEnd(GameObject player)
		{
			for (currentDuration = duration; currentDuration > 0; 
				currentDuration--)
			{
				timerController.UpdateSeconds(currentDuration);
				yield return new WaitForSeconds(1);
			}
			timerController.EndTimer(); 
			player.GetComponent<PowerUpController>().RemovePowerUp();
		}
	}
}
