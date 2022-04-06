using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WinnerController : MonoBehaviour
{
	[SerializeField] private UnityEvent<bool, int, bool> OnPlayerOneCounter;
	[SerializeField] private UnityEvent<bool, int, bool> OnPlayerTwoCounter;
	[SerializeField] private bool isTwoPlayers;
	[SerializeField] private int playerOnePoints;
	[SerializeField] private int playerTwoPoints;
	private TextMeshProUGUI winnerText;
	private bool isPlayerOneWinner;
	private bool isPlayerTwoWinner;

	private void Start()
	{
		winnerText = GetComponent<TextMeshProUGUI>();
		
		//One Player
		if (!ModeSelectController.IsTwoPlayers() && !isTwoPlayers)
		{
			if (PlayerCountManager.playerOnePoints != 0)
			{
				winnerText.text = "Player One: " 
					+ PlayerCountManager.playerOnePoints;
			}
			else
			{
				winnerText.text = "Player One: " + playerOnePoints;
			}
		}
		
		//Two Players
		else
		{
			if (PlayerCountManager.playerOnePoints
				> PlayerCountManager.playerTwoPoints 
				|| playerOnePoints > playerTwoPoints)
			{
				winnerText.text = "Player One Wins!";
				isPlayerOneWinner = true;
			}
			else if (PlayerCountManager.playerTwoPoints
				> PlayerCountManager.playerOnePoints
				|| playerTwoPoints > playerOnePoints)
			{
				winnerText.text = "Player Two Wins!";
				isPlayerTwoWinner = true;
			}
			else
			{
				winnerText.text = "It's a Draw!";
				isPlayerOneWinner = true;
				isPlayerTwoWinner = true;
			}
			OnPlayerOneCounter?.Invoke(true, 
				PlayerCountManager.playerOnePoints, isPlayerOneWinner);
			OnPlayerTwoCounter?.Invoke(false, 
				PlayerCountManager.playerTwoPoints, isPlayerTwoWinner);
		}
	}
}	

