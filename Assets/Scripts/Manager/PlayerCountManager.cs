using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountManager : MonoBehaviour
{
    [SerializeField] private bool isTwoPlayers;

	private void Awake()
	{
		if (ModeSelectController.IsTwoPlayers())
		{
			isTwoPlayers = true;
		}
		if (!isTwoPlayers)
		{
			OnePlayerMode();
		}
		else
		{
		    TwoPlayerMode();
		}
	}

	private void OnePlayerMode()
	{
		Destroy(GameObject.Find("2P User Interface"));
		Destroy(GameObject.Find("2P Player One"));
		Destroy(GameObject.Find("2P Player Two"));
	}

	private void TwoPlayerMode()
	{
		Destroy(GameObject.Find("1P User Interface"));
		Destroy(GameObject.Find("1P Player"));
	}
}
