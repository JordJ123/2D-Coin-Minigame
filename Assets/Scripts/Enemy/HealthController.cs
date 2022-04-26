using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
	[RequireComponent(typeof(Animator))]
	public class HealthController : MonoBehaviour
	{
		[SerializeField] public UnityEvent<string, bool> OnDeathAnimation;
		[SerializeField] public UnityEvent OnDeath;
		[SerializeField] public UnityEvent OnRevive;
		[SerializeField] public UnityEvent OnReset;
		[SerializeField] private float reviveDuration;
		private Animator animator;
		private bool isAlive = true;

		private void Awake()
		{
			animator = GetComponent<Animator>();
			OnDeathAnimation.AddListener(animator.SetBool);
		}

		private void Start()
		{
			OnDeathAnimation?.Invoke("Dead", false);
		}

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
			OnDeathAnimation?.Invoke("Dead", true);
			StartCoroutine(Revive());
		}

		private IEnumerator Revive()
		{
			yield return new WaitForSeconds(reviveDuration);
			isAlive = true;
			OnDeathAnimation?.Invoke("Dead", false);
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
