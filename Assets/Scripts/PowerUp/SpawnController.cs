using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace PowerUp
{
    public class SpawnController : MonoBehaviour
    {
        private static SpawnController[] powerUps;
        private static SpawnController currentPowerUp;
        private GameObject gameObj;

        public static void StaticAwake()
        {
            powerUps = FindObjectsOfType<SpawnController>(true);
            SpawnPowerUp();
        }
        
        public static void SpawnPowerUp()
        {
            if (currentPowerUp != null)
            {
                currentPowerUp.Despawn();
            }
            currentPowerUp = powerUps[Random.Range(0, powerUps.Length)];
            currentPowerUp.Respawn();
        }

        private void Awake()
        {
            gameObj = gameObject;
            Despawn();
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