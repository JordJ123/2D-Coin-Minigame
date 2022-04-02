using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class ProfileSelectController : MonoBehaviour
{
	[SerializeField] private UnityEvent<string> OnProfileSelect;
	[SerializeField] private UnityEvent<bool> OnCreateButton;
	[SerializeField] private UnityEvent<string> OnCreate;
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

	public void Create()
	{
		profileNames.Insert(profileNames.Count - 1, 
			profileNames.Count.ToString());
		profileSelected = profileNames.Count - 2;
		Directory.CreateDirectory(Application.persistentDataPath + "\\"
			+ profileNames[profileSelected]);
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleCreateButton();
		OnCreate?.Invoke(profileNames[profileSelected]);
	}

	public void AddProfileName(string profileName)
	{
		if (profileNames[profileSelected].Equals(""))
		{
			profileSelected++;
		}
		profileNames.Insert(profileNames.Count - 1, 
			profileNames.Count.ToString());
	}

	public void Left()
	{
		profileSelected--;
		if (profileSelected < 0)
		{
			profileSelected = profileNames.Count - 1;
			
		}
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleCreateButton();
	}
	
	public void Right()
	{
		profileSelected++;
		if (profileSelected > profileNames.Count - 1)
		{
			profileSelected = 0;
		}
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleCreateButton();
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
