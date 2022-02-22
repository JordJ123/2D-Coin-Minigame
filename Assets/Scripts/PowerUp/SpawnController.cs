using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace PowerUp
{
    public class SpawnController : MonoBehaviour
    {
        private static GameObject[] powerUps;
        private static GameObject currentPowerUp;
        private GameObject gameObj;

        public static void StaticAwake()
        {
            powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
            foreach (var powerUp in powerUps)
            {
                powerUp.GetComponent<SpawnController>().Despawn();
            }
            SpawnPowerUp();
        }
        
        public static void SpawnPowerUp()
        {
            if (currentPowerUp != null)
            {
                currentPowerUp.GetComponent<SpawnController>().Despawn();
            }
            currentPowerUp = powerUps[Random.Range(0, powerUps.Length)];
            currentPowerUp.GetComponent<SpawnController>().Respawn();
        }

        private void Awake()
        {
            gameObj = gameObject;
        }

        public void Respawn()
        {
            gameObj.SetActive(true);
        }

        public void Despawn()
        {
            gameObj.SetActive(false);
            currentPowerUp = null;
        }
    }
}