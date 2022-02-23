using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
    {
        private SpriteRenderer spriteRend;
        private Color baseColour;
        
        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            baseColour = spriteRend.color;
        }

        public void SetNormal()
        {
            spriteRend.color = baseColour;
        }

        public void SetVunerable()
        {
            spriteRend.color = Color.red;
        }
        
        public void FlipLeft()
        {
            spriteRend.flipX = false;
        }
        
        public void FlipRight()
        {
            spriteRend.flipX = true;
        }
    }
}

