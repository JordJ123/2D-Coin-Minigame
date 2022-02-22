using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Transform))]
    public class SpawnController : MonoBehaviour
    {
        private GameObject gameObj;
        private Transform gameObjTransform;
        private Vector3 spawnVector;

        private void Awake()
        {
            gameObj = gameObject;
            gameObjTransform = GetComponent<Transform>();
            spawnVector = gameObjTransform.position;
        }

        public void Despawn()
        {
            gameObj.SetActive(false);
        }

        public void Respawn()
        {
            gameObjTransform.position = spawnVector;
            gameObj.SetActive(true);
        }
    }
}
