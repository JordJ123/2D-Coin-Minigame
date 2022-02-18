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
        
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (collider.tag == "Enemy")
            {
                Respawn();
            }
        }
        
        private void Respawn()
        {
            gameObjTransform.position = spawnVector;
        }
    }
}