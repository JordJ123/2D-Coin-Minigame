using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ModeSelectController : MonoBehaviour
{
	[SerializeField] private UnityEvent OnPlay;
	[SerializeField] private UnityEvent<string> OnError;
    [SerializeField] private ProfileSelectController playerOneSelect;
    [SerializeField] private ProfileSelectController playerTwoSelect;
	private static string playerOneName = "";
	private static string playerTwoName = "";
	private static bool isTwoPlayers;
	private AudioSource audio;

	public static string GetPlayerOneName()
	{
		return playerOneName;
	}
	
	public static string GetPlayerTwoName()
	{
		return playerTwoName;
	}
	
	public static bool IsTwoPlayers()
	{
		return isTwoPlayers;
	}

	public void OnePlayer()
	{
		playerOneName = playerOneSelect.GetProfileName();
		if (playerOneName == "")
		{
			OnError?.Invoke("Please select a profile for Player One");
		}
		else
		{
			OnPlay?.Invoke();
			isTwoPlayers = false;
			SceneManager.LoadScene("GameScreen");
		}
	}
    
	public void TwoPlayers()
	{
		playerOneName = playerOneSelect.GetProfileName();
		playerTwoName = playerTwoSelect.GetProfileName();
		if (playerOneName == "" && playerTwoName == "")
		{
			OnError?.Invoke("Please select a profile for both Player One and "
				+ "Player Two");
		} 
		else if (playerOneName == "")
		{
			OnError?.Invoke("Please select a profile for Player One");
		} 
		else if (playerTwoName == "")
		{
			OnError?.Invoke("Please select a profile for Player Two");
		}
		else if (playerOneName.Equals(playerTwoName))
		{
			OnError?.Invoke("Please select unique profiles for the players");
		}
		else
		{
			OnPlay?.Invoke();
			isTwoPlayers = true;
			SceneManager.LoadScene("GameScreen");
		}
	}

	public void Credits()
	{
		SceneManager.LoadScene("CreditsScreen");
	}
	
    public void Quit()
    {
         Application.Quit();
    }
}
