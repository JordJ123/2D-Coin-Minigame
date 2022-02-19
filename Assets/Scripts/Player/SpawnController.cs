using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Transform))]
    public class SpawnController : MonoBehaviour
    {
        private Transform gameObjTransform;
        private Vector3 spawnVector;

        private void Awake()
        {
            gameObjTransform = GetComponent<Transform>();
            spawnVector = gameObjTransform.position;
        }

        public void Respawn()
        {
            gameObjTransform.position = spawnVector;
        }
    }
}