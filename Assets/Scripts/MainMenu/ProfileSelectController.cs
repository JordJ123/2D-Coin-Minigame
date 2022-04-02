using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class ProfileSelectController : MonoBehaviour
{
	[SerializeField] private UnityEvent<string> OnProfileSelect;
	private List<string> profileNames = new List<string>();
	private int profileSelected;
	
	private void Awake()
	{
		DirectoryInfo[] profiles = new DirectoryInfo(
			Application.persistentDataPath).GetDirectories();
		foreach (var profile in profiles)
		{
			profileNames.Add(profile.Name);
		}
	}

	public string GetProfileName()
	{
		return profileNames[profileSelected];
	}

	private void Start()
	{
		if (profileNames.Count >= 1)
		{
			OnProfileSelect?.Invoke(profileNames[0]);
		}
	}

	public void Left()
	{
		profileSelected--;
		if (profileSelected < 0)
		{
			profileSelected = profileNames.Count - 1;
		}
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
	}
	
	public void Right()
	{
		profileSelected++;
		if (profileSelected > profileNames.Count - 1)
		{
			profileSelected = 0;
		}
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
	}
}
