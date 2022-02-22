using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
    {
        private SpriteRenderer spriteRend;
        
        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
        }

        public void SetNormal()
        {
            
        }
        
        public void SetSword()
        {
            
        }
    }
}