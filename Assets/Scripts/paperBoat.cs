using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperBoat : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject player;
    public Rigidbody2D playerRb;
    public BoxCollider2D bc;
    public SpriteRenderer paperBoatSprite;
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
    private float boatMovementForce;
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

        boatMovementForce = 0.8f;


    }




    void Update()
    {
        if (lastTime - Time.time < -spawnDelayTime && !(speed == 0.5f))
        {

            //bc.enabled = true;
            speed = 0.5f;
        }




        


        //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        paperBoatSprite.sprite = SelectSprite();


    }

    private void FixedUpdate()
    {
        Vector2 direction = playerRb.position - rb.position;
        angle = Mathf.Atan2(direction.y, direction.x);
        rb.rotation = angle * (180 / Mathf.PI);
        rb.AddForceAtPosition(direction.normalized * boatMovementForce, this.rb.position);
    }



    void Flip()
    {
        if (((dAngle > 120f && dAngle < 180f) || (dAngle > -180f && dAngle < -120f)) && !paperBoatSprite.flipY)
        {
            paperBoatSprite.flipY = true;
        }
        if (((dAngle > 0f && dAngle < 60f) || (dAngle > -60f && dAngle < 0f)) && paperBoatSprite.flipY)
        {
            paperBoatSprite.flipY = false;
        }
        /*if (rb.velocity.y < 0)
        {
            paperBoatSprite.flipY = true;
           
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
