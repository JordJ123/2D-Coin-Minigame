using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Death");
    }
}
