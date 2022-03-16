using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achievement
{
	public abstract class AchievementController : MonoBehaviour
	{
		protected AchievementSystem achievementSystem;
		protected Achievement achievement;

		protected void Awake()
		{
			achievementSystem = transform
				.parent.GetComponent<AchievementSystem>();
		}
	}
}