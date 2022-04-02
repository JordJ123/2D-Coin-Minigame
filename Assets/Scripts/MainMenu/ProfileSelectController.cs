using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ProfileSelectController : MonoBehaviour
{
	[SerializeField] private UnityEvent<string> OnProfileSelect;
	[SerializeField] private UnityEvent<bool> OnProfileButtons;
	[SerializeField] private UnityEvent<bool> OnCreateButton;
	[SerializeField] private UnityEvent<string> OnCreate;
	[SerializeField] private UnityEvent<string> OnDelete;
	private static string profileNameSelected;
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
		ToggleButtons();
	}

	public void Create()
	{
		profileNames.Insert(profileNames.Count - 1, 
			profileNames.Count.ToString());
		profileSelected = profileNames.Count - 2;
		Directory.CreateDirectory(Application.persistentDataPath + "/"
			+ profileNames[profileSelected]);
		OnCreate?.Invoke(profileNames[profileSelected]);
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleButtons();
	}

	public void AddProfileName(string profileName)
	{
		if (profileNames[profileSelected].Equals(""))
		{
			profileSelected++;
		}
		profileNames.Insert(profileNames.Count - 1, profileName);
		ToggleButtons();
	}

	public void Delete()
	{
		Directory.Delete(Application.persistentDataPath + "/"
			+ profileNames[profileSelected], true);
		OnDelete?.Invoke(profileNames[profileSelected]);
		profileNames.Remove(profileNames[profileSelected]);
		if (profileSelected != 0)
		{
			profileSelected--;
		}
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleButtons();
	}

	public void RemoveProfileName(string profileName)
	{
		if (profileNames[profileSelected].Equals("") 
			|| (profileSelected == profileNames.Count - 2 
				&& profileSelected != 0))
		{
			profileSelected--;
		}
		profileNames.Remove(profileName);
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleButtons();
	}

	public void ViewProfile()
	{
		profileNameSelected = profileNames[profileSelected];
		SceneManager.LoadScene("ProfileScreen");
	}

	public void Left()
	{
		profileSelected--;
		if (profileSelected < 0)
		{
			profileSelected = profileNames.Count - 1;
			
		}
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleButtons();
	}
	
	public void Right()
	{
		profileSelected++;
		if (profileSelected > profileNames.Count - 1)
		{
			profileSelected = 0;
		}
		OnProfileSelect?.Invoke(profileNames[profileSelected]);
		ToggleButtons();
	}

	private void ToggleButtons()
	{
		if (!profileNames[profileSelected].Equals("")) {
			OnProfileButtons?.Invoke(true); 
			OnCreateButton?.Invoke(false);
		}
		else
		{
			OnProfileButtons?.Invoke(false);
			OnCreateButton?.Invoke(true);
		}
	}
}
