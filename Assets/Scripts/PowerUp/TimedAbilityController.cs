using System;
using System.Collections;
using UI;
using UnityEngine;

namespace PowerUp
{
	public abstract class TimedAbilityController : AbilityController
	{
		[SerializeField] protected int duration;

		protected void Awake()
		{
			base.Awake();
		}
		
		public abstract override void Ability(GameObject player);

		protected abstract void AbilityStart(GameObject player);

		protected abstract IEnumerator AbilityEnd(
			Player.PowerUpController playerPowerUpController);
	}
}
