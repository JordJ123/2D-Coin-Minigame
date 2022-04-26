using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
	public class HealthController : MonoBehaviour
	{
		[SerializeField] public UnityEvent OnDeath;
		[SerializeField] public UnityEvent OnRevive;
		[SerializeField] public UnityEvent OnReset;
		[SerializeField] private float reviveDuration;
		private bool isAlive = true;

		private void OnDisable()
		{
			OnDeath.RemoveAllListeners();
		}

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
