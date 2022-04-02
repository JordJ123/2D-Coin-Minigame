using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectController : MonoBehaviour
{
    [SerializeField] private ProfileSelectController playerOneSelect;
    [SerializeField] private ProfileSelectController playerTwoSelect;
	private static string playerOneName = "";
	private static string playerTwoName = "";
	private static bool isTwoPlayers;

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
		if (playerOneName != "")
		{
			isTwoPlayers = false;
			SceneManager.LoadScene("GameScreen");
		}
	}
    
	public void TwoPlayers()
	{
		playerOneName = playerOneSelect.GetProfileName();
		playerTwoName = playerTwoSelect.GetProfileName();
		if (playerOneName != "" && playerTwoName != "" 
			&& !playerOneName.Equals(playerTwoName))
		{
			isTwoPlayers = true;
			SceneManager.LoadScene("GameScreen");
		}
	}
	
    public void Quit()
    {
         Application.Quit();
    }
}
