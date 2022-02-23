using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Player 
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteController))]
    public class MovementController : MonoBehaviour
    {
        //Serialise Fields
        [SerializeField] private float moveDistance;
        private float horizontalSpeed;
        private bool lookingRight = true;

        //Initialise Fields
        private Rigidbody2D rb2D;
        private SpriteController spriteController;
        private Vector2 velocity;

        //Awake is called during initialisation
        private void Awake() 
        {
            rb2D = GetComponent<Rigidbody2D>();
            spriteController = GetComponent<SpriteController>();
            velocity = new Vector2();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            velocity = rb2D.velocity;
            velocity.x = MoveHorizontal();
            velocity.y = MoveVertical();
            rb2D.velocity = velocity;
        }

        private float MoveHorizontal()
        {
            
            horizontalSpeed = Input.GetAxis("Horizontal") * moveDistance;
            if (horizontalSpeed < 0 && lookingRight)
            {
                lookingRight = false;
                spriteController.FlipLeft();
            } 
            else if (horizontalSpeed > 0 && !lookingRight)
            {
                lookingRight = true;
                spriteController.FlipRight();
            }
            return horizontalSpeed;
        }
        
        private float MoveVertical()
        {
            return Input.GetAxis("Vertical") * moveDistance;
        }
    }
}


