using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
	public void PlayAgain()
    {
        SceneManager.LoadScene("GameScreen");
    }
    
    public void Return()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
