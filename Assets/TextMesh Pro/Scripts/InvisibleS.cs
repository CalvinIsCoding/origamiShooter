using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleS : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject player;
    public Rigidbody2D playerRb;
    public BoxCollider2D bc;
    public SpriteRenderer paperPlaneSprite;
    public float angle;
    public float dAngle;
    public Rigidbody2D rb;
    [SerializeField]
    private Enemy _enemy;

    //Sprites
    public Sprite N;
    public Sprite NE;
    public Sprite E;


    private float speed;
    private float lastTime;
    private float timer;
    private float spawnDelayTime = 0.8f;
    private float slitherSpeed;
    private float waveSpeed;
    // private bool spriteToggle;
    //private int blinks = 6;

    public bool isBlink;
    public bool invisible;
    public GameObject leadSEnemy;
    public GameObject invisibleS;
    public Vector2 direction;

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

        slitherSpeed = 0.25f;
        waveSpeed = 1f;
        
           // Instantiate(leadSEnemy, invisibleS.transform.position, invisibleS.transform.rotation, invisibleS.transform);
        


    }




    void Update()
    {
        if (lastTime - Time.time < -spawnDelayTime && !(speed == 0.5f))
        {

            //bc.enabled = true;
            speed = 0.5f;
        }





        //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        //paperPlaneSprite.sprite = SelectSprite();


    }
    private void FixedUpdate()
    {
        //continuous force
        /* Vector2 direction = playerRb.position - rb.position;
         angle = Mathf.Atan2(direction.y, direction.x);
         rb.rotation = 90 + ( angle * (180 / Mathf.PI));
         rb.AddForceAtPosition(direction.normalized * slitherSpeed, this.rb.position);
 */

        //periodic forcing

        timer += Time.fixedDeltaTime;
        direction = playerRb.position - rb.position;
        Vector2 perpDirection = new Vector2(-direction.y, direction.x);
        float perpAngle = Mathf.Atan2(perpDirection.x, perpDirection.y);
        angle = Mathf.Atan2(direction.y, direction.x);
        rb.rotation = 90 + (angle * (180 / Mathf.PI));
        Debug.Log("angle: " + angle);
        Debug.Log("perpAngle: " + perpAngle);
        Debug.Log(Mathf.Sin(timer));



        if (!_enemy.isBlown)
        {
            
            
                rb.AddForceAtPosition(direction.normalized * (slitherSpeed * 2f), this.rb.position);

           
            
                //rb.AddForceAtPosition(perpDirection.normalized * waveSpeed * (Mathf.Sin(timer * 2f)), this.rb.position);

            


            //rb.AddForceAtPosition(perpDirection.normalized * waveSpeed * 0.05f, this.rb.position);

        }


    }



    void Flip()
    {
        if (((dAngle > 120f && dAngle < 180f) || (dAngle > -180f && dAngle < -120f)) && !paperPlaneSprite.flipY)
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
