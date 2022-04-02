using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	private static bool isTwoPlayers;

	public static bool IsTwoPlayers()
	{
		return isTwoPlayers;
	}

	public void OnePlayer()
	{
		isTwoPlayers = false;
        SceneManager.LoadScene("GameScreen");
    }
    
	public void TwoPlayers()
	{
		isTwoPlayers = true;
		SceneManager.LoadScene("GameScreen");
	}
	
    public void Quit()
    {
         Application.Quit();
    }
}
