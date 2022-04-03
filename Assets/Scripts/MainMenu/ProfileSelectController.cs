using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ProfileSelectController : MonoBehaviour
{
	[SerializeField] private UnityEvent<string> OnProfileSelect;
	[SerializeField] private UnityEvent<bool> OnProfileButtons;
	[SerializeField] private UnityEvent<bool> OnNewButton;
	[SerializeField] private UnityEvent<bool> OnCreateButtons;
	[SerializeField] private UnityEvent<string> OnCreate;
	[SerializeField] private UnityEvent<string> OnDelete;
	[SerializeField] private UnityEvent<string> OnError;
	[SerializeField] private bool isPlayerOne;
	private static string profileNameSelected;
	private List<string> profileNames = new List<string>();
	private int profileSelected;
	private string playerMessage = "";
	

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
		OnCreateButtons?.Invoke(false);
	}
	
	public void Create() {
		OnNewButton?.Invoke(false);
	    OnCreateButtons?.Invoke(true);
	}

	public void Save(string profileName)
	{
		if (isPlayerOne)
		{
			playerMessage = "One";
		}
        else
		{
			playerMessage = "Two";
		}
		if (profileName == "")
		{
			OnError?.Invoke(string.Format("Please enter a name for the new "
				+ "profile for Player {0}", playerMessage));
		}
		else if (profileNames.Contains(profileName))
		{
			OnError?.Invoke(string.Format("Name already exists for the new "
				+ "profile for Player {0}", playerMessage));
		}
		else
		{
			try
			{
				Directory.CreateDirectory(Application.persistentDataPath + "/"
					+ profileName);
				profileNames.Insert(profileNames.Count - 1, profileName);
				profileSelected = profileNames.Count - 2;
				OnCreate?.Invoke(profileNames[profileSelected]);
				OnProfileSelect?.Invoke(profileNames[profileSelected]);
				ToggleButtons();
				OnCreateButtons?.Invoke(false);
			}
			catch (IOException exception)
			{
				OnError?.Invoke(string.Format("Error saving the name for the "
					+ "new profile for Player {0}", playerMessage));
			}
		}
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

	public void Cancel()
	{
		OnNewButton?.Invoke(true);
		OnCreateButtons?.Invoke(false);
	}

	public void Delete()
	{
		Directory.Delete(Application.persistentDataPath + "/"
			+ profileNames[profileSelected], true);
		OnDelete?.Invoke(profileNames[profileSelected]);
		profileNames.Remove(profileNames[profileSelected]);
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
			OnNewButton?.Invoke(false);
		}
		else
		{
			OnProfileButtons?.Invoke(false);
			OnNewButton?.Invoke(true);
		}
	}
}
