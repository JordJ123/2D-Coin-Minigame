using System.Collections;
using UI;
using UnityEngine;

namespace PowerUp
{
	public abstract class TimedAbilityController : MonoBehaviour, 
		IAbilityController
	{
		[SerializeField] protected TimerController timerController;
		[SerializeField] protected int duration;
		protected int currentDuration;

		public abstract void Ability(GameObject player);

		protected abstract void AbilityStart(GameObject player);

		protected abstract IEnumerator AbilityEnd(GameObject player);
	}
}
