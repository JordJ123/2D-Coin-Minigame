using UnityEngine;

namespace PowerUp
{
	public class LivesAbilityController : AbilityController
	{
		private void Awake()
		{
			base.Awake();
		}
		
		public override void Ability(GameObject player)
		{
			Collect();
			player.GetComponent<Player.PowerUpController>().SetLivesPowerUp();
		}
	}
}
