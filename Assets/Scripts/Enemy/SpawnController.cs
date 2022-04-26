using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
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
