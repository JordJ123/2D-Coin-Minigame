using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountManager : MonoBehaviour
{
    [SerializeField] private bool isTwoPlayers;

	private void Start()
	{
		if (!isTwoPlayers)
		{
			Destroy(GameObject.Find("2P Player One"));
			Destroy(GameObject.Find("2P Player Two"));
		}
		else
		{
			Destroy(GameObject.Find("1P Player"));
		}
	}
}
