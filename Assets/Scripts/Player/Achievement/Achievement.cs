using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Achievement
{
	public class Achievement
	{
		private string idName;
		private string displayName;
		private string description;
		private Color colour;
		private bool isUnlocked;
	
		public Achievement(string idName, string displayName, 
			string description, Color colour)
		{
			this.idName = idName;
			this.displayName = displayName;
			this.description = description;
			this.colour = colour;
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

		public Color GetColour()
		{
			return colour;
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
