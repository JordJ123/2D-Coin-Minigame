using UnityEngine;

namespace PowerUp
{
	public class LivesAbilityController : AbilityController
	{
		public override void Ability(GameObject player)
		{
			Collect();
			player.GetComponent<Player.PowerUpController>().SetLivesPowerUp();
		}
	}
}
