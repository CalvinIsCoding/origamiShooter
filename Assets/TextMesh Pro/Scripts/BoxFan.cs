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
    private float boxFanMovementForce;
    private float farFromPlayerDistance = 2f;
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
    public Boss boxFan;

    //Overheat Variables
    public float maxOverheat;
    public bool overHeating;
    public float coolDownFactor;
    public float overHeatTime;
    public int overHeatCounter;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        lastTime = Time.time;
        boxFanMovementForce = 14.75f;

        boxFan.health = 100;

        //Setting Overheat variables
        maxOverheat = 5f;
        overHeating = false;
        coolDownFactor = 2f;
        overHeatTime = 0f;
        overHeatCounter = 0;
    }

    
    void Update()
    {
        currentTimeBetweenBullets = currentTimeBetweenBullets + Time.deltaTime;

        //Overheating
        if (!overHeating)
        {
            overHeatTime = overHeatTime + Time.deltaTime;

        }
        else if (overHeating)
        {
            overHeatTime = overHeatTime - (Time.deltaTime * coolDownFactor);
            //overHeatCounter = overHeatCounter - 1;

        }


        OverHeat(overHeatTime);
    }
    private void FixedUpdate()
    {
        Vector2 direction = playerRb.position - rb.position;
        //Debug.Log(direction.magnitude);
        if (direction.magnitude < farFromPlayerDistance)
        {
            angle = Mathf.Atan2(direction.y, direction.x);
            rb.rotation = angle * (180 / Mathf.PI);


        }
        else
        {
            angle = Mathf.PI + Mathf.Atan2(direction.y, direction.x);
            rb.rotation =  angle * (180 / Mathf.PI);
        }


        
        
        rb.AddForceAtPosition(direction.normalized * boxFanMovementForce, this.rb.position);

        if ((currentTimeBetweenBullets - timePerBullet) > 0 )
        {

            bullet = Instantiate(airBulletPrefab, firePoint.position, firePoint.rotation);
            currentTimeBetweenBullets = 0;
            PushBack(playerRb.position);


            // overHeatCounter = overHeatCounter + 1;

        }

    }

    private void PushBack(Vector3 playerPosition)
    {
        playerPosition.z = 0;
        //fanDirection = new Vector2(playerPosition.x, playerPosition.y);\
        fanDirection = new Vector2(firePoint.position.x, firePoint.position.y);

       rb.AddForce((-fanDirection + this.rb.position).normalized * airPushBackForce, ForceMode2D.Impulse);

    }

    private void OverHeat(float overHeatCounter)
    {
        if (overHeatCounter >= maxOverheat)
        {
            StartCoroutine(CoolDown());
            overHeating = true;

        }

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(overHeatTime / coolDownFactor);
        overHeating = false;

    }
}
