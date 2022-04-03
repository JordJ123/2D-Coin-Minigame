using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InputFieldController : MonoBehaviour
{
	[SerializeField] private UnityEvent<string> OnSave;
	private TMP_InputField inputFieldText;

	private void Awake() {
		inputFieldText = GetComponent<TMP_InputField>();
	}

	public void Save()
	{
		OnSave?.Invoke(inputFieldText.text);
	}
}
