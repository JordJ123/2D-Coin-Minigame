using UnityEngine;

namespace PowerUp
{
	public class LivesAbilityController : MonoBehaviour, IAbilityController
	{
		public void Ability(GameObject player)
		{
			player.GetComponent<PowerUpController>().SetLivesPowerUp();
		}
	}
}
