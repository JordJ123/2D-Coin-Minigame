using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class StatisticController : MonoBehaviour
	{
		private TextMeshProUGUI statistic;
        
		private void Awake() {
			statistic = GetComponent<TextMeshProUGUI>();
		}

		public void DisplayStatistic(float value)
		{
			statistic.text = value.ToString();
		}
	}
}