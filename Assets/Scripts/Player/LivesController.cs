using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    [SerializeField] private int lives;

    public void LoseLife()
    {
        lives--;
        if (lives == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
