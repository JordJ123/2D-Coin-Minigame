using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public class HealthController : MonoBehaviour
	{
		[SerializeField] private float reviveDuration;
		
		public event Action OnDeath;
		public event Action OnRevive;
		public event Action OnReset;
		private bool isAlive = true;

		public bool IsAlive()
		{
			return isAlive;
		}

		public void Die()
		{
			isAlive = false;
			OnDeath?.Invoke();
			StartCoroutine(Revive());
		}

		private IEnumerator Revive()
		{
			yield return new WaitForSeconds(reviveDuration);
			isAlive = true;
			OnRevive?.Invoke();
		}
		
		private void Reset()
		{
			StopAllCoroutines();
			isAlive = true;
			OnReset?.Invoke();
		}
	}
}
