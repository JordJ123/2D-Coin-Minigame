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

		public void SetNormal()
		{
			spriteRend.color = Color.white;
			spriteRend.sprite = normalSprite;
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
			SetColour(Color.white, spriteRend.color.a);
			spriteRend.sprite = attackPowerUpSprite;
        }

		public void SetSpeedPowerUp()
		{
			SetColour(speedPowerUpColour, spriteRend.color.a);
			spriteRend.sprite = normalSprite;
		}
		
		private void SetColour(Color color, float opacity)
		{
			color.a = opacity;
			spriteRend.color = color;
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