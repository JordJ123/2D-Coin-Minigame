using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Point
{
    public class SpawnController : MonoBehaviour
    {
        private GameObject gameObj;

        private void Awake()
        {
            gameObj = gameObject;
        }
    
        public void Despawn() 
        {
            gameObj.SetActive(false);
        }

        public void Respawn()
        {
            gameObj.SetActive(true);
        }
    }
}
