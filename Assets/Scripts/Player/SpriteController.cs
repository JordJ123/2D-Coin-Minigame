using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
    {
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite attackPowerUpSprite;
		[SerializeField] private Color speedPowerUpColour;
        private SpriteRenderer spriteRend;

        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
        }

		public void SetNormal()
		{
			spriteRend.color = Color.white;
			spriteRend.sprite = normalSprite;
		}

        public void SetAttackPowerUp()
        {
			spriteRend.color = Color.white;
			spriteRend.sprite = attackPowerUpSprite;
        }

		public void SetSpeedPowerUp()
		{
			spriteRend.color = speedPowerUpColour;
			spriteRend.sprite = normalSprite;
		}

		public void FlipLeft()
        {
            spriteRend.flipX = true;
        }
        
        public void FlipRight()
        {
            spriteRend.flipX = false;
        }
    }
}