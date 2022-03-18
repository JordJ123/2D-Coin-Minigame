using System.Collections;
using System.Collections.Generic;
using SaveData;
using UnityEngine;

namespace Achievement
{
	public class Achievement
	{
		private string idName;
		private string displayName;
		private string description;
		private bool isUnlocked;
	
		public Achievement(string idName, string description)
		{
			this.idName = idName;
			this.displayName = idName;
			this.description = description;
		}

		public string GetIdName()
		{
			return idName;
		}
		
		public string GetDisplayName()
		{
			return displayName;
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
