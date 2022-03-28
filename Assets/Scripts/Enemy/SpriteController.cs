using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(HealthController))]
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteController : MonoBehaviour
	{
		[SerializeField] private Color twoPlayerColour;
		[SerializeField] private float deadOpacity;
		
		private HealthController healthController;
        private SpriteRenderer spriteRend;
        private Color baseColour;
		private bool isBaseFlipX;
		private List<Color> currentColours = new List<Color>();

		void Awake()
        {
			healthController = GetComponent<HealthController>();
            spriteRend = GetComponent<SpriteRenderer>();
            baseColour = spriteRend.color;
			isBaseFlipX = spriteRend.flipX;
		}
		
		private void Start()
		{
			healthController.OnDeath += SetDead;
			healthController.OnRevive += SetAlive;
			healthController.OnReset += Reset;
		}
		
		private void OnDisable()
		{
			healthController.OnDeath -= SetDead;
			healthController.OnRevive -= SetAlive;
			healthController.OnReset -= Reset;
		}

        public void SetVunerable(Color colour)
        {
			if (CompareColours(spriteRend.color, Color.white))
			{
				SetColour(colour, spriteRend.color.a);
			}
			else if (!CompareColours(spriteRend.color, colour))
			{
				SetColour(twoPlayerColour, spriteRend.color.a);
			}
			if (!currentColours.Contains(colour))
			{
				currentColours.Add(colour);
			}
		}
		
		public void SetInvunerable(Color colour)
		{
			currentColours.Remove(colour);
			if (CompareColours(spriteRend.color, colour))
			{
				SetColour(Color.white, spriteRend.color.a);
			}
			else
			{
				SetColour(currentColours[0], spriteRend.color.a);
			}
		}

		private void SetDead()
		{
			SetColour(spriteRend.color, deadOpacity);
			spriteRend.flipX = isBaseFlipX;
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

		private bool CompareColours(Color colourOne, Color colourTwo)
		{
			return colourOne.r == colourTwo.r
				&& colourOne.g == colourTwo.g
				&& colourOne.b == colourTwo.b;
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
			SetAlive();
			spriteRend.flipX = isBaseFlipX;
		}
    }
}

