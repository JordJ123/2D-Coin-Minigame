using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class CameraLoopController : MonoBehaviour
	{
		private Bounds bounds;
		private Transform tf;
		private Vector3 position;
		
		private Camera mainCamera;
		private float cameraRightX;
		private float cameraLeftX;
		
		private void Awake()
		{
			bounds = GetComponent<BoxCollider2D>().bounds;
			tf = transform;
			mainCamera = Camera.main;
		}

		private void Start()
		{
			CalulcateCameraBounds();
		}

		private void FixedUpdate()
		{
			CheckPosition();   
		}

		private void CheckPosition()
		{
			position = tf.position;
			if (position.x < cameraLeftX)
			{
				position.x = cameraRightX;
			} 
			else if (position.x > cameraRightX) {
				 position.x = cameraLeftX;
			}
			tf.position = position;
		}

		private void CalulcateCameraBounds()
		{
			cameraRightX = mainCamera.transform.position.x 
				+ mainCamera.orthographicSize * mainCamera.aspect
				+ bounds.extents.x * 2;
			cameraLeftX = mainCamera.transform.position.x 
				- mainCamera.orthographicSize * mainCamera.aspect
				- bounds.extents.x * 2;
		}
	}
}
