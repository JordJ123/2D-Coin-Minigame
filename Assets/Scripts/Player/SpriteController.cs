using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
	{
		[SerializeField] private float invulnerableOpacity;
        [SerializeField] private Sprite attackPowerUpSprite;
		[SerializeField] private Color speedPowerUpColour;
        private SpriteRenderer spriteRend;
		private Sprite normalSprite;

        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
			normalSprite = spriteRend.sprite;
		}

		public void SetInvulnerable()
		{
			SetColour(spriteRend.color, invulnerableOpacity);
		}
		
		public void SetVulnerable()
		{
			SetColour(spriteRend.color, 1);
		}

        public void SetAttackPowerUp()
        {
			spriteRend.sprite = attackPowerUpSprite;
        }
		
		public void RemoveAttackPowerUp()
		{
			spriteRend.sprite = normalSprite;
		}

		public void SetSpeedPowerUp()
		{
			SetColour(speedPowerUpColour, spriteRend.color.a);
		}
		
		public void RemoveSpeedPowerUp()
		{
			SetColour(Color.white, spriteRend.color.a);
		}

		private void SetColour(Color color, float opacity)
		{
			color.a = opacity;
			spriteRend.color = color;
		}

		public bool IsLookingRight()
		{
			return !spriteRend.flipX;
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