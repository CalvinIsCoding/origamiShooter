using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    public GameObject player;
    public Enemy enemy;
    public Rigidbody2D playerRb;
    public Rigidbody2D rb;
    public float angle;
    public float ninjaStarMovementForce;
    private Vector2 direction;

    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;



    //public Wall wall;
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        playerRb = player.GetComponent<Rigidbody2D>();
        ninjaStarMovementForce = 0.2f;
        direction = playerRb.position - rb.position;
        //angle = Mathf.Atan2(direction.y, direction.x);
        rb.AddForceAtPosition(direction.normalized  * ninjaStarMovementForce, this.rb.position);
        //rb.velocity = initialVelocity;

        //Physics.IgnoreLayerCollision(8, 8,true);
    }


    
    

   /* private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }*/

    private void Update()
    {
        if (!enemy.isBlown)
        {



            rb.AddForceAtPosition(direction.normalized * ninjaStarMovementForce, this.rb.position);
        }
        else
        {
            direction = rb.velocity;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(!enemy.isBlown)
        {*/
        Wall wall = collision.gameObject.GetComponent<Wall>();
            if (wall != null)
            {
                Bounce(collision.contacts[0].normal);
            }
       // }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        //var speed = lastFrameVelocity.magnitude;
        direction = Vector3.Reflect(direction.normalized, collisionNormal);


        rb.AddForceAtPosition(direction.normalized * ninjaStarMovementForce, this.rb.position);
    }
}

    

