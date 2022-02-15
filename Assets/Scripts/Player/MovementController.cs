using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Player Object
[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    //Serialise Fields
    [SerializeField] private float moveDistance;

    //Initialise Fields
    private Rigidbody2D rb2D;
    private Vector2 velocity;

    //Awake is called during initialisation
    private void Awake() 
    {
        rb2D = GetComponent<Rigidbody2D>();
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
        velocity.x = Input.GetAxis("Horizontal") * moveDistance;
        velocity.y = Input.GetAxis("Vertical") * moveDistance;
        rb2D.velocity = velocity;
    }
}
