using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
    {
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite swordSprite;
        private SpriteRenderer spriteRend;

        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
        }

        public void SetNormal()
        {
            spriteRend.sprite = normalSprite;
        }
        
        public void SetSword()
        {
            spriteRend.sprite = swordSprite;
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