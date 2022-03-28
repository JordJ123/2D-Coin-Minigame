using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private KeyCode left;
	[SerializeField] private KeyCode right;
	[SerializeField] private KeyCode up;
	[SerializeField] private KeyCode down;

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
