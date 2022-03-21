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
		public static event Action<int> OnSecond;
		protected int currentDuration;

		public abstract void Ability(GameObject player);

		protected abstract void AbilityStart(GameObject player);

		protected abstract IEnumerator AbilityEnd(GameObject player);

		protected void InvokeOnSecondEvent(int currentDuration)
		{
			OnSecond?.Invoke(currentDuration);
		}
	}
}
