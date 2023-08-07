using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject player;
    public Rigidbody2D playerRb;
    public BoxCollider2D bc;
    public SpriteRenderer paperPlaneSprite;
    public float angle;
    public float dAngle;
    public Rigidbody2D rb;

    //Sprites
    public Sprite N;
    public Sprite NE;
    public Sprite E;


    private float speed;
    private float lastTime;
    private float spawnDelayTime = 0.8f;
    private float planeMovementForce;
   // private bool spriteToggle;
    //private int blinks = 6;

    public bool isBlink;

    void Start()
    {
        //bc.enabled = false;

        //spriteToggle = false;

        //isBlink = true;
        //StartCoroutine(Blink());

        player = GameObject.FindWithTag("Player");

        playerRb = player.GetComponent<Rigidbody2D>();

        lastTime = Time.time;

        speed = 0f;

        planeMovementForce = 0.75f;
       

    }
    



    void Update()
    {
        if(lastTime - Time.time < -spawnDelayTime && !(speed == 0.5f))
        {
            
            //bc.enabled = true;
            speed = 0.5f;
        }



        

            //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

             paperPlaneSprite.sprite = SelectSprite();
            

    }
    private void FixedUpdate()
    {

        Vector2 direction = playerRb.position - rb.position;
        angle = Mathf.Atan2(direction.y, direction.x);
        rb.rotation = angle * (180 / Mathf.PI);
        rb.AddForceAtPosition(direction.normalized * planeMovementForce, this.rb.position);

    }



    void Flip()
    {
        if(((dAngle > 120f  && dAngle < 180f) || (dAngle > -180f && dAngle < -120f)) && !paperPlaneSprite.flipY)
        {
            paperPlaneSprite.flipY = true;
        }
        if (((dAngle > 0f && dAngle < 60f) || (dAngle > -60f && dAngle < 0f)) && paperPlaneSprite.flipY)
        {
            paperPlaneSprite.flipY = false;
        }
        /*if (rb.velocity.y < 0)
        {
            paperPlaneSprite.flipY = true;
           
        }*/
        
    }
    Sprite SelectSprite()
    {
        dAngle = angle * (180f / Mathf.PI);
        Sprite selectedSprite = null;
        if ((dAngle > 60f && dAngle < 120f) || (dAngle > -120f && dAngle < -60f))
        {
            selectedSprite = N;

        }
        else if ((dAngle > 30f && dAngle < 60f) || (dAngle > -60f && dAngle < -30f) || (dAngle > 120f && dAngle < 150f) || (dAngle > -150f && dAngle < -120f))
        {
            selectedSprite = NE;
            Flip();

        }
        else if ((dAngle > -180f && dAngle < -150f) || (dAngle > 0f && dAngle < 30f) || (dAngle > 150f && dAngle < 180f) || (dAngle > -30f && dAngle < 0f))
        {
            selectedSprite = E;
            Flip();

        }

        return selectedSprite;
    }
}
