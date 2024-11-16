using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampersand : MonoBehaviour
{

    //public GameObject enemy;
    public GameObject player;
    public Rigidbody2D playerRb;
    public CircleCollider2D cc;
    public SpriteRenderer ampersandSprite;
    public float angle;
    public float dAngle;
    public Rigidbody2D rb;

    //Sprites
    /*public Sprite N;
    public Sprite NE;
    public Sprite E;
*/

    private float speed;
    private float lastTime;
    private float timer;
    private float spawnDelayTime = 0.8f;
    private float ampersandMovementForce;
    // private bool spriteToggle;
    //private int blinks = 6;

    public bool isBlink;
    public Animator animator;
    public bool isForcing;

    //Audio
    public AudioSource ampersandSound;

    void Start()
    {
        //bc.enabled = false;

        //spriteToggle = false;

        //isBlink = true;
        //StartCoroutine(Blink());

        player = GameObject.FindWithTag("Player");

        playerRb = player.GetComponent<Rigidbody2D>();

        lastTime = Time.time;

        timer = 0;

        speed = 0f;

        ampersandMovementForce = 1.0f;


    }




    void Update()
    {
        if (lastTime - Time.time < -spawnDelayTime && !(speed == 0.5f))
        {

            //bc.enabled = true;
            speed = 0.5f;
        }





        //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        //ampersandSprite.sprite = SelectSprite();


    }
    private void FixedUpdate()
    {
        //continuous force
        /* Vector2 direction = playerRb.position - rb.position;
         angle = Mathf.Atan2(direction.y, direction.x);
         rb.rotation = 90 + ( angle * (180 / Mathf.PI));
         rb.AddForceAtPosition(direction.normalized * ampersandMovementForce, this.rb.position);
 */

        //periodic forcing

        timer += Time.fixedDeltaTime;
        Vector2 direction = playerRb.position - rb.position;
        angle = Mathf.Atan2(direction.y, direction.x);
        rb.rotation = (angle * (180 / Mathf.PI));
        //Flip();

        if (timer > 0.75f)
        {

            isForcing = true;
            animator.SetBool("IsForcing", true);
            rb.AddForceAtPosition(direction.normalized * (ampersandMovementForce * 40), this.rb.position);
           // ampersandSound.Play();
            timer -= 0.75f;

        }
        else
        {
            animator.SetBool("IsForcing", false);
            isForcing = false;
        }

    }



    void Flip()
    {
        if (((dAngle > 120f && dAngle < 180f) || (dAngle > -180f && dAngle < -120f)) && !ampersandSprite.flipY)
        {
            ampersandSprite.flipY = true;
        }
        if (((dAngle > 0f && dAngle < 60f) || (dAngle > -60f && dAngle < 0f)) && ampersandSprite.flipY)
        {
            ampersandSprite.flipY = false;
        }
        /*if (rb.velocity.y < 0)
        {
            ampersandSprite.flipY = true;
           
        }*/

    }
  /*  Sprite SelectSprite()
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
*/

}
