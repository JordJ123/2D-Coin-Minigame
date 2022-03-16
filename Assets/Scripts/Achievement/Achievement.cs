using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achievement
{
	public class Achievement
	{
		private string name;
		private string description;
		private bool isUnlocked;
	
		public Achievement(string name, string description)
		{
			this.name = name;
			this.description = description;
		}

		public string GetName()
		{
			return name;
		}
		
		public string GetDescription()
		{
			return description;
		}

		public bool IsUnlocked()
		{
			return isUnlocked;
		}

		public void Unlock()
		{
			isUnlocked = true;
		}
	}
}
