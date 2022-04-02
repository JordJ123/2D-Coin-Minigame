using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class ProfileSelectController : MonoBehaviour
{
	[SerializeField] private UnityEvent<string> OnProfileSelect;
	[SerializeField] private UnityEvent<bool> OnCreateButton;
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
		profileNames.Add("");
	}

	public string GetProfileName()
	{
		return profileNames[profileSelected];
	}

	private void Start()
	{
		OnProfileSelect?.Invoke(profileNames[0]);
		ToggleCreateButton();
	}

	public void Left()
	{
		profileSelected--;
		if (profileSelected < 0)
		{
			profileSelected = profileNames.Count - 1;
			
		}
		ToggleCreateButton();
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
	}
	
	public void Right()
	{
		profileSelected++;
		if (profileSelected > profileNames.Count - 1)
		{
			profileSelected = 0;
		}
		ToggleCreateButton();
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
	}

	private void ToggleCreateButton()
	{
		if (profileNames[profileSelected].Equals("")) {
			OnCreateButton?.Invoke(true);
		}
		else
		{
			OnCreateButton?.Invoke(false);
		}
	}
}
