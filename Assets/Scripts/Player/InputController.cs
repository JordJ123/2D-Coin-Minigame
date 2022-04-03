using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private bool isPlayerOne;
	private KeyCode left;
	private KeyCode right;
	private KeyCode up;
	private KeyCode down;

	private void Awake()
	{
		if (isPlayerOne)
		{
			if (ProfileSelectController.isPlayerOneWASD)
			{
				left = KeyCode.A;
				right = KeyCode.D;
				up = KeyCode.W;
				down = KeyCode.S;
			}
			else
			{
				left = KeyCode.LeftArrow;
				right = KeyCode.RightArrow;
				up = KeyCode.UpArrow;
				down = KeyCode.DownArrow;
			}
		}
		else
		{
			if (!ProfileSelectController.isPlayerOneWASD)
			{
				left = KeyCode.A;
				right = KeyCode.D;
				up = KeyCode.W;
				down = KeyCode.S;
			}
			else
			{
				left = KeyCode.LeftArrow;
				right = KeyCode.RightArrow;
				up = KeyCode.UpArrow;
				down = KeyCode.DownArrow;
			}
		}
	}
	
	public int GetHorizontalAxis()
	{
		if (Input.GetKey(left))
		{
			return -1;
		}
		if (Input.GetKey(right))
		{
			return 1;
		}
		return 0;
	}
	
	public int GetVerticalAxis()
	{
		if (Input.GetKey(up))
		{
			return 1;
		}
		if (Input.GetKey(down))
		{
			return -1;
		}
		return 0;
	}
}
