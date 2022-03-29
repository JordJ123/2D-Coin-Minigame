using System;
using System.Collections;
using UI;
using UnityEngine;

namespace PowerUp
{
	public abstract class TimedAbilityController : MonoBehaviour, 
		IAbilityController
	{
		[SerializeField] protected int duration;

		public abstract void Ability(GameObject player);

		protected abstract void AbilityStart(GameObject player);

		protected abstract IEnumerator AbilityEnd(
			Player.PowerUpController playerPowerUpController);
	}
}
