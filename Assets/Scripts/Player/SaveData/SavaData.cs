using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Player.SaveData
{
	[Serializable]
	public abstract class SaveData
	{
		private string name;
		
		private static string filePath;
		private static FileStream fileStream;
		private static SaveData loadedData;
		
		public SaveData(string name)
		{
			this.name = name;
		}

		public static SaveData Load(string name)
		{
			filePath = GetFilePath(name);
			if (!File.Exists(filePath))
			{
				return null;
			}
			fileStream = File.Open(filePath, FileMode.Open);
			loadedData = new BinaryFormatter().Deserialize(fileStream) 
				as SaveData;
			fileStream.Close();
			return loadedData;
		}
		
		public static void Save(SaveData saveData)
		{
			filePath = GetFilePath(saveData.getName());
			if (!File.Exists(filePath))
			{
				new FileInfo(filePath).Directory.Create();
				File.Create(filePath).Close();
			}
			fileStream = File.Open(filePath, FileMode.Create);
			new BinaryFormatter().Serialize(fileStream, saveData);
			fileStream.Close();
		}

		private static string GetFilePath(string name)
		{
			return Path.Combine(Application.persistentDataPath, name + ".sav");
		}

		public string getName()
		{
			return name;
		}
	}
}