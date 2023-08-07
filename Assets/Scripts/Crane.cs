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
    // private bool spriteToggle;
    //private int blinks = 6;

    public bool isBlink;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        playerRb = player.GetComponent<Rigidbody2D>();

        lastTime = Time.time;

        speed = 0f;

        craneMovementForce = 60f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isBlink)
        {
            Orient();
        }
        
        if (lastTime - Time.time < -spawnDelayTime && !(speed == 0.5f))
        {
            Orient();

            speed = 0.5f;
            //rb.velocity = direction.normalized * 2f;
        }
    }
    private void FixedUpdate()
    {

        
        
        rb.AddForceAtPosition(direction.normalized * craneMovementForce, this.rb.position);
         

    }

    //Orients the Crane so it will travel in the direction the player was in when the Crane began moving
    private void Orient()
    {
        direction = playerRb.position - rb.position;
        angle = Mathf.Atan2(direction.y, direction.x);
        rb.rotation = angle * (180 / Mathf.PI);
    }
}
