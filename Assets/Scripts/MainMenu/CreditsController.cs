using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
	public void DSI()
	{
		Application.OpenURL("https://0x72.itch.io/16x16-dungeon-tileset");
	}
	
	public void DSII()
	{
		Application.OpenURL("https://0x72.itch.io/dungeontileset-ii");
	}
	
	public void Return()
    {
		SceneManager.LoadScene("MenuScreen");
    }
}
