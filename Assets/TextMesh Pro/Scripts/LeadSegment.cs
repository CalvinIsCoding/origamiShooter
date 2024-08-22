using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadSegment : MonoBehaviour
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
    float lastForce;
    Vector2 direction;
    // private bool spriteToggle;
    //private int blinks = 6;

    public bool isBlink;
    public bool invisible;
    public GameObject leadSEnemy;
    public GameObject invisibleS;
    public InvisibleS _invisibleS;
    public GameObject _sFollowingSegment;
    private Vector2 sPosition;
    private HingeJoint2D hinge;
    private float segmentTimer;

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

        slitherSpeed = 7f;
        waveSpeed = 3f;
        lastForce = waveSpeed;
        direction = new Vector2(1f, 1f);
        //Instantiate(invisibleS);



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
        float forcing = 3f * waveSpeed * Mathf.Sin(timer * 4f);
        

        timer += Time.fixedDeltaTime;
        segmentTimer += Time.fixedDeltaTime;



        if ( forcing * lastForce <= 0)
        {
            sPosition = rb.position;
           
        }
        rb.rotation = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * (180 / Mathf.PI);
        direction = playerRb.position - sPosition;
        // _invisibleS = invisibleS.GetComponent<InvisibleS>();
        // direction = _invisibleS.direction;
        lastForce = forcing;
        //Transform parentTransform = this.GetComponentInParent<Transform>();
        //Quaternion direction = parentTransform.rotation;
        //this.transform.rotation = direction;
        //direction.Normalize();
        Vector2 perpDirection = new Vector2(-direction.y, direction.x);
        float perpAngle = Mathf.Atan2(perpDirection.x, perpDirection.y);
        //angle = Mathf.Atan2(direction.y, direction.x);
       // rb.rotation = 90 + (angle * (180 / Mathf.PI));
        //Debug.Log("x:  " + rb.velocity.x);
       // Debug.Log("y:  " + rb.velocity.y);
        // Debug.Log("perpAngle: " + perpAngle);
        //Debug.Log(Mathf.Sin(timer));



        if (!_enemy.isBlown)
        {
            
            rb.AddForceAtPosition(direction.normalized * (slitherSpeed * 2f), this.rb.position);

           // Vector2 parentVelocity = transform.parent.GetComponent<Rigidbody2D>().velocity;

            rb.AddForceAtPosition(perpDirection.normalized * forcing, this.rb.position);
           // rb.velocity = new Vector2(parentVelocity.x,waveSpeed * (Mathf.Sin(timer * 2f)));



            //rb.AddForceAtPosition(perpDirection.normalized * waveSpeed * 0.05f, this.rb.position);

        }
        if(segmentTimer >= 1f)
        {
           // Instantiate(_sFollowingSegment);
            //hinge.connectedBody();
            segmentTimer = 0f;
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
