using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFan : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject player;
    public Rigidbody2D playerRb;
    public BoxCollider2D bc;
    public SpriteRenderer boxFanSprite;
    public float angleOfFirePoint;
    public float dangleOfFirePoint;
    public Rigidbody2D rb;

    //Sprites
    public Sprite N;
    public Sprite NE;
    public Sprite E;


    private float speed;
    private float lastTime;
    private float spawnDelayTime = 0.8f;
    private float boxFanMovementForce;
    private float farFromPlayerDistance = 1.5f;
    private float distanceDeadband = 0.5f;
    private bool inDeadbandDistance;
    // private bool spriteToggle;
    //private int blinks = 6;


    //Shooting Variables
    public Transform firePoint;
    public GameObject airBulletPrefab;
    private GameObject bullet;

    //Bullet Variables
    public float currentTimeBetweenBullets;
    public float timePerBullet = 0.2f;



    //public Rigidbody2D rb;
    public Vector2 fanDirection;
    public float movementThrust;
    private float airPushBackForce = 1.12f;

    public bool isBlink;

    //Scriptable object data
    public BossObject boxFan;

    //Overheat Variables
    public float maxOverheat;
    public bool overHeating;
    public float coolDownFactor;
    public float overHeatTime;
    public int overHeatCounter;

    //turn red on hit variables
    private bool isRed;
    private float timeSlowDown;
    private float hitTime;

    //check if close to wall
    private float minimumDistanceFromFire;
    private int defaultLayer;
    // public FirePlace firePlace;
    FirePlace firePlace;
    public ContactFilter2D contactFilter = new ContactFilter2D();
    private bool angryFromHit;


    //Animation
    public Animator animator;

    public AudioSource airBlowingBoxFanAudioSource;
    public AudioSource otherSoundBoxFanAudioSource;
    public AudioClip OverHeatBoxFanAudio;
    public AudioClip AirBoxFanAudio;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        lastTime = Time.time;
        boxFanMovementForce = 11.75f;

        boxFan.health = 50;

        timePerBullet = 0.05f;
        airPushBackForce = 1.1f;

        //Setting Overheat variables
        maxOverheat = 5f;
        overHeating = false;
        coolDownFactor = 2f;
        overHeatTime = 0f;
        overHeatCounter = 0;

        //setting hit variables
        isRed = false;
        hitTime = 0.15f;
        timeSlowDown = 0.90f;

        minimumDistanceFromFire = 0.65f;
        defaultLayer = 0;
        angryFromHit = false;


    }

    
    void Update()
    {
        animator.SetFloat("Horizontal", fanDirection.x);
    }
  
private void FixedUpdate()
    {
        
        

        Vector2 boxFanDirection;
        currentTimeBetweenBullets = currentTimeBetweenBullets + Time.fixedDeltaTime;

        //Overheating
        if (!overHeating)
        {
            overHeatTime = overHeatTime + Time.fixedDeltaTime;

        }
        else if (overHeating)
        {
            overHeatTime = overHeatTime - (Time.fixedDeltaTime * coolDownFactor);
            //overHeatCounter = overHeatCounter - 1;

        }


        OverHeat(overHeatTime);
        
        if (angryFromHit)
        {

            boxFanMovementForce = 23;
            boxFanDirection = new Vector2(0, 0) - rb.position;
            StartCoroutine(GettingLessAngry());
            //angryFromHit = false;


        }
        else
        {
            boxFanMovementForce = 11.75f;
            boxFanDirection = DetermineDirection();
            //float angleOfFirePointOfShooting = Mathf.Atan2(playerRb.position.y - rb.position.y, playerRb.position.y - rb.position.y);
            firePoint.transform.rotation = Quaternion.Euler(0, 0, angleOfFirePoint * Mathf.Rad2Deg);
            firePoint.transform.localPosition = new Vector2(Mathf.Cos(angleOfFirePoint) * 0.18f, Mathf.Sin(angleOfFirePoint) * 0.18f);
        }
        
       


        
        
        rb.AddForceAtPosition(boxFanDirection.normalized * boxFanMovementForce, this.rb.position);

        if ((currentTimeBetweenBullets - timePerBullet) > 0 )
        {
            
            if (overHeating == false)
            {
                animator.SetBool("IsBlowing", true);
                bullet = Instantiate(airBulletPrefab, firePoint.position, firePoint.rotation);
                
                currentTimeBetweenBullets = 0;
                if (angryFromHit == false)
                {
                    PushBack();
                }
                if (airBlowingBoxFanAudioSource.isPlaying == false)
                {
                    airBlowingBoxFanAudioSource.Play();
                }
            }
            else
            {
                animator.SetBool("IsBlowing", false);
            }
           
            //Movement gets erratic if fan still pushes itself back when this happens.
            
           



        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(rb.position, minimumDistanceFromFire);
    }

    private void PushBack()
    {
        
        //fanDirection = new Vector2(playerPosition.x, playerPosition.y);\
        fanDirection = new Vector2(firePoint.position.x, firePoint.position.y);

       rb.AddForce((-fanDirection + this.rb.position).normalized * airPushBackForce, ForceMode2D.Impulse);

    }

    private void OverHeat(float overHeatCounter)
    {
        if (overHeatCounter >= maxOverheat)
        {
            otherSoundBoxFanAudioSource.PlayOneShot(OverHeatBoxFanAudio);
            StartCoroutine(CoolDown());
            overHeating = true;

        }

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(overHeatTime / coolDownFactor);
        overHeating = false;

    }
   public  IEnumerator TurnSpriteRed()
    {
        boxFanSprite.color = Color.red;
        Time.timeScale = timeSlowDown;
        isRed = true;
        //angryFromHit = true;
        yield return new WaitForSeconds(hitTime * timeSlowDown);
        Time.timeScale = 1f;
        isRed = false;
        boxFanSprite.color = Color.white;
    }
    public IEnumerator GettingLessAngry()
    {
        float angerTime = 1.5f;
        int angerFrames = 30;
        for (int i = 0; i < angerFrames; i++)
        {
            angleOfFirePoint = angleOfFirePoint + 0.01f;
            firePoint.transform.rotation = Quaternion.Euler(0, 0, angleOfFirePoint * Mathf.Rad2Deg);
            firePoint.transform.localPosition = new Vector2(Mathf.Cos(angleOfFirePoint) * 0.18f, Mathf.Sin(angleOfFirePoint) * 0.18f);
            //Debug.Log(angleOfFirePoint);
            yield return new WaitForSeconds(angerTime / angerFrames);

        }
       
       // rb.AddTorque(-1f);
        angryFromHit = false;
    }

    public Vector2 DetermineDirection()
    {
        Collider2D[] nearEntity = new Collider2D[5];

        int objectsDetected = Physics2D.OverlapCircle(rb.position, minimumDistanceFromFire, contactFilter, nearEntity);

        Vector2 direction;

        //The box fan should try to avoid the fire
        if (objectsDetected > 0)
        { 
            direction = new Vector2(0, 0) - rb.position;

            angleOfFirePoint = Mathf.PI + Mathf.Atan2(direction.y, direction.x);
            //rb.rotation = angleOfFirePoint * (180 / Mathf.PI);
        }
        else
        {
            direction = playerRb.position - rb.position;
        }

        if(direction.magnitude > farFromPlayerDistance)
        {
            inDeadbandDistance = true;
        }
        else if (direction.magnitude < (farFromPlayerDistance - distanceDeadband))
        {
            inDeadbandDistance = false;
        }
        //I do this so the boss moves quickly towards the player when it is far away, and then blows air towards the player when it is close.
        if (inDeadbandDistance || objectsDetected > 0)
        {
            angleOfFirePoint = Mathf.PI + Mathf.Atan2(direction.y, direction.x);
            
            // rb.rotation = angleOfFirePoint * (180 / Mathf.PI);

        }

        else
        {
            angleOfFirePoint =  Mathf.Atan2(direction.y, direction.x);

            // rb.rotation = angleOfFirePoint * (180 / Mathf.PI);
        }

       

        return direction;
    }
    
    
   /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        FirePlace firePlace = collision.gameObject.GetComponent<FirePlace>();
        if (firePlace != null)
        {
            StartCoroutine(TurnSpriteRed());
        }
        
    }*/
    

}
