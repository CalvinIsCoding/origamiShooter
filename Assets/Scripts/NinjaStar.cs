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
    private Vector2 initialDirectionOfTravel;

    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;



    //public Wall wall;
    void Start()
    {
        initialDirectionOfTravel = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        player = GameObject.FindWithTag("Player");

        playerRb = player.GetComponent<Rigidbody2D>();
        //ninjaStarMovementForce = 0.2f;
        direction = initialDirectionOfTravel;
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

    private void FixedUpdate()
    {
       
        if (!enemy.isBlown)
        {
            rb.AddForceAtPosition(direction.normalized * ninjaStarMovementForce, this.rb.position);
            //direction = playerRb.position - rb.position;


        }
        else
        {
            direction = rb.velocity;
        }
        
        

        Debug.Log("ex is blown" + enemy.isBlown);
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
    
    public void OnCollisionStay2D(Collision2D collision)
    {
        Wall wall = collision.gameObject.GetComponent<Wall>();
        if (wall != null && this.rb.velocity.magnitude < 0.8f * minVelocity)
        {
           
                BumpBackTowardsCenter();

            
        }
    }
    
    private void Bounce(Vector3 collisionNormal)
    {
        //var speed = lastFrameVelocity.magnitude;
        direction = Vector3.Reflect(direction.normalized, collisionNormal);


        //rb.AddForceAtPosition(direction.normalized * ninjaStarMovementForce, this.rb.position);
    }
    private void BumpBackTowardsCenter()
    {
        
        Vector2 directionOfBump = new Vector2(-this.rb.position.x, -this.rb.position.y);
        rb.AddForceAtPosition(directionOfBump.normalized,this.rb.position);
    }
}

    

