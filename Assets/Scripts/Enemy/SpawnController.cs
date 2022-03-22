using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(HealthController))]
    [RequireComponent(typeof(Transform))]
    public class SpawnController : MonoBehaviour
    {
		private HealthController healthController;
		private Transform gameObjTransform;
        private Vector3 spawnVector;

        private void Awake()
        {
			healthController = GetComponent<HealthController>();
			gameObjTransform = GetComponent<Transform>();
            spawnVector = gameObjTransform.position;
            Player.TriggerDetector.OnDeath += Respawn;
		}
		
		private void Start()
		{
			healthController.OnDeath += Respawn;
		}
		
		private void OnDisable()
		{
		    Player.TriggerDetector.OnDeath -= Respawn;
			healthController.OnDeath -= Respawn;
		}

        public void Respawn()
		{
			gameObjTransform.position = spawnVector;
		}
	}
}
