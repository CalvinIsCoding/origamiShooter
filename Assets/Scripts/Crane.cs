using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{

    //public GameObject enemy;
    public GameObject player;
    public Rigidbody2D playerRb;
    public PolygonCollider2D bc;
    
    public float angle;
    public float dAngle;
    public Rigidbody2D rb;

    private float speed;
    private float lastTime;
    private float spawnDelayTime = 0.8f;
    private float craneMovementForce;
    Vector2 direction;
   // public bool Dragging;
    // private bool spriteToggle;
    //private int blinks = 6;

  // Enemy.isBlink;

    public Animator animator;
    public Enemy enemy;
    public bool windingUp = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        playerRb = player.GetComponent<Rigidbody2D>();

        lastTime = Time.time;

        speed = 0f;

        craneMovementForce = 10f;
        animator.SetBool("isBlinking", true);
        animator.SetBool("Dragging", false);


    }

    // Update is called once per frame
    void Update()
    {
       
        
        
       /* if (lastTime - Time.time < -spawnDelayTime && !(speed == 0.5f))
        {
            

            speed = 0.5f;
            //rb.velocity = direction.normalized * 2f;
        }*/
    }
    private void FixedUpdate()
    {
        if (Time.time - lastTime <= 0.7f)
        {

            Orient();

        }
        else if (!windingUp)
        {
            lastTime = Time.time;
            animator.SetTrigger("WindingUp");
            windingUp = true;

        }

        if (!enemy.isBlink && (Time.time - lastTime > 0.7f))
        {
            //Orient();
            animator.SetBool("Dragging", false);
            rb.drag = 2;
            rb.freezeRotation = true;
           rb.AddForceAtPosition(direction.normalized * craneMovementForce, rb.position);

        }
        if(Time.time - lastTime > 1.5f)
        {
            rb.freezeRotation = false;
            rb.drag = 10;
            windingUp = false;
            animator.SetBool("Dragging", true);
            //Orient();
            //enemy.isBlink = true;
            lastTime = Time.time;
        }


    }

    //Orients the Crane so it will travel in the direction the player was in when the Crane began moving
    private void Orient()
    {
        direction = playerRb.position - rb.position;
        angle = Mathf.Atan2(direction.y, direction.x);
       
        rb.MoveRotation( angle * (180f/Mathf.PI) + 90f);
    }
}
