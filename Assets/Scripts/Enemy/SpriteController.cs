using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(HealthController))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
	{
		[SerializeField] private float deadOpacity;
		
		private HealthController healthController;
        private SpriteRenderer spriteRend;
        private Color baseColour;
		private bool isBaseFlipX;

		void Awake()
        {
			healthController = GetComponent<HealthController>();
            spriteRend = GetComponent<SpriteRenderer>();
            baseColour = spriteRend.color;
			isBaseFlipX = spriteRend.flipX;
		}
		
		private void Start()
		{
			Player.TriggerDetector.OnDeath += Reset;
			healthController.OnDeath += SetDead;
			healthController.OnRevive += SetAlive;
		}
		
		private void OnDisable()
		{
			Player.TriggerDetector.OnDeath -= Reset;
			healthController.OnDeath -= SetDead;
			healthController.OnRevive -= SetAlive;
		}

        public void SetVunerable()
        {
			SetColour(Color.red, spriteRend.color.a);
		}
		
		public void SetInvunerable()
		{
			SetColour(Color.white, spriteRend.color.a);
		}

		private void SetDead()
		{
			SetColour(spriteRend.color, deadOpacity);
			Reset();
		}

		private void SetAlive()
		{
			SetColour(spriteRend.color, 1);
		}

		private void SetColour(Color color, float opacity)
		{
			color.a = opacity;
			spriteRend.color = color;
		}
        
        public void FlipLeft()
        {
            spriteRend.flipX = false;
        }
        
        public void FlipRight()
        {
            spriteRend.flipX = true;
        }

		private void Reset()
		{
			spriteRend.flipX = isBaseFlipX;
		}
    }
}

