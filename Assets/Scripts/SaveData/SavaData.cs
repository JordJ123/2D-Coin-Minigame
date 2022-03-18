using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public abstract class SaveData
	{
		private string name;

		public SaveData(string name)
		{
			this.name = name;
		}

		public string getName()
		{
			return name;
		}
	}
}