using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerController : MonoBehaviour
{
	[SerializeField] private bool isTwoPlayers;
	[SerializeField] private int playerOnePoints;
	[SerializeField] private int playerTwoPoints;
	private TextMeshProUGUI winnerText;

	private void Awake()
	{
		winnerText = GetComponent<TextMeshProUGUI>();
		
		//One Player
		if (!ModeSelectController.IsTwoPlayers() && !isTwoPlayers)
		{
			winnerText.text = "";
		}
		
		//Two Players
		else
		{
			if (PlayerCountManager.playerOnePoints
				> PlayerCountManager.playerTwoPoints 
				|| playerOnePoints > playerTwoPoints)
			{
				winnerText.text = "Player One Wins!";
			}
			else if (PlayerCountManager.playerTwoPoints
				> PlayerCountManager.playerOnePoints
				|| playerTwoPoints > playerOnePoints)
			{
				winnerText.text = "Player Two Wins!";
			}
			else
			{
				winnerText.text = "It's a Draw!";
			}
		}
	}
}	

