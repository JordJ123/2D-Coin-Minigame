using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Screen.MenuScreen
{
	public class ProfileSelectController : MonoBehaviour
	{
		[SerializeField] private UnityEvent<string> OnProfileSelect;
		[SerializeField] private UnityEvent<bool> OnArrowButtons;
		[SerializeField] private UnityEvent<bool> OnProfileButtons;
		[SerializeField] private UnityEvent<bool> OnNewButton;
		[SerializeField] private UnityEvent<bool> OnCreateButtons;
		[SerializeField] private UnityEvent OnCancel;
		[SerializeField] private UnityEvent<string> OnCreate;
		[SerializeField] private UnityEvent<string> OnDelete;
		[SerializeField] private UnityEvent OnSwapControls;
		[SerializeField] private UnityEvent<string> OnError;
		[SerializeField] private bool isPlayerOne;
		public static bool isPlayerOneWASD { private set; get; } = true;
		public static string profileNameSelected;
		private List<string> profileNames = new List<string>();
		private GameObject audioGameObject;
		private MenuSoundController audio;
		private int profileSelected;
		private string playerMessage = "";
		private bool createMode;
		

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
			audioGameObject = GameObject.FindWithTag("Sound");
			if (audioGameObject != null)
			{
				audio = audioGameObject.GetComponent<MenuSoundController>();
			}
			if (profileNames.Count <= 1)
			{
				OnArrowButtons?.Invoke(false);
			}
			OnProfileSelect?.Invoke(profileNames[0]);
			ToggleButtons();
			OnCreateButtons?.Invoke(false);
		}
		
		public void Create() {
			if (audio != null) audio.SaveSound();
			OnArrowButtons?.Invoke(false);
			OnNewButton?.Invoke(false);
		    OnCreateButtons?.Invoke(true);
			createMode = true;
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
					if (audio != null) audio.SaveSound();
					OnCreate?.Invoke(profileNames[profileSelected]);
					OnProfileSelect?.Invoke(profileNames[profileSelected]);
					ToggleButtons();
					OnArrowButtons?.Invoke(true);
					OnCreateButtons?.Invoke(false);
					createMode = false;
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
			if (!createMode)
			{
				OnArrowButtons?.Invoke(true);
			}
		}

		public void Cancel()
		{
			if (audio != null) audio.ErrorSound();
			if (profileNames.Count > 1)
			{
				OnArrowButtons?.Invoke(true);
			}
			OnCancel?.Invoke();
			OnNewButton?.Invoke(true);
			OnCreateButtons?.Invoke(false);
			createMode = false;
		}

		public void Delete()
		{
			if (audio != null) audio.ErrorSound();
			Directory.Delete(Application.persistentDataPath + "/"
				+ profileNames[profileSelected], true);
			OnDelete?.Invoke(profileNames[profileSelected]);
			profileNames.Remove(profileNames[profileSelected]);
			OnProfileSelect?.Invoke(profileNames[profileSelected]);
			if (profileNames.Count <= 1)
			{
				OnArrowButtons?.Invoke(false);
			}
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
			if (profileNames.Count <= 1)
			{
				OnArrowButtons?.Invoke(false);
			}
			ToggleButtons();
		}

		public void ViewProfile()
		{
			if (audio != null) audio.ForwardSound();
			profileNameSelected = profileNames[profileSelected];
			SceneManager.LoadScene("ProfileScreen");
		}

		public void Left()
		{
			if (audio != null) audio.ForwardSound();
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
			if (audio != null) audio.ForwardSound();
			profileSelected++;
			if (profileSelected > profileNames.Count - 1)
			{
				profileSelected = 0;
			}
			OnProfileSelect?.Invoke(profileNames[profileSelected]);
			ToggleButtons();
		}

		public void SwapControls()
		{
			if (audio != null) audio.ForwardSound();
			isPlayerOneWASD = !isPlayerOneWASD;
			OnSwapControls?.Invoke();
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
}
