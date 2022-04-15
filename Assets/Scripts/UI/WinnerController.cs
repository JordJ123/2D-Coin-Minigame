using System.Collections;
using System.Collections.Generic;
using Screen.GameScreen;
using Screen.MenuScreen;
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
			if (PlayerCountController.playerOnePoints != 0)
			{
				winnerText.text = "Player One: " 
					+ PlayerCountController.playerOnePoints;
			}
			else
			{
				winnerText.text = "Player One: " + playerOnePoints;
			}
		}
		
		//Two Players
		else
		{
			if (PlayerCountController.playerOnePoints
				> PlayerCountController.playerTwoPoints 
				|| playerOnePoints > playerTwoPoints)
			{
				winnerText.text = "Player One Wins!";
				isPlayerOneWinner = true;
			}
			else if (PlayerCountController.playerTwoPoints
				> PlayerCountController.playerOnePoints
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
				PlayerCountController.playerOnePoints, isPlayerOneWinner);
			OnPlayerTwoCounter?.Invoke(false, 
				PlayerCountController.playerTwoPoints, isPlayerTwoWinner);
		}
	}
}	

