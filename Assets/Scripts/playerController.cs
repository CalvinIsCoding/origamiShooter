using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    //Movement Variables
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 currentVelocity;
    [SerializeField]
    private float movementSpeed = 12f;
    public Rigidbody2D characterRigidBody;

    public float boostForce = 10f;
    private bool isBoost;


    public int lifeCount;





    //Shooting Variables
    public GameObject airBulletPrefab;
    public GameObject misslePrefab;
    private GameObject bullet;
    public GameObject Player;
    public GameObject parryBox;
    public CapsuleCollider2D parryBoxCollider;
    public Rigidbody2D rb;
    public Vector2 fanDirection;
    public float movementThrust;
    private float airPushBackForce = 0.12f;

    //Overheat variables
    public bool overHeating = false;
    public int overHeatCounter;
    public OverheatBar overheatBar;
    public float maxOverheat = 5f;
    private float coolDownFactor = 2f;

    //Bullet Variables
    public float currentTimeBetweenBullets;
    public float overHeatTime;
    public float timePerBullet = 0.2f;


    public Transform firePoint;

    public DestroyMode _DestroyMode;
    //Destruction Mode
    /* public bool isDestroyMode;
     private float timeSinceDestroy;
     private float destroyModeTime = 10f;*/

    public Animator animator;



    void Start()
    {
        characterRigidBody = GetComponent<Rigidbody2D>();
        parryBoxCollider = parryBox.GetComponent<CapsuleCollider2D>();
        parryBox.SetActive(false);
        lifeCount = 3;
        currentTimeBetweenBullets = 0f;
        isBoost = false;

        overHeatCounter = 0;
        overHeatTime = 0;

        overheatBar.SetMaxOverheat(maxOverheat);


    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        currentVelocity = characterRigidBody.velocity;


        //Aiming
      


        currentTimeBetweenBullets = currentTimeBetweenBullets + Time.deltaTime;
        
        //parry
        if (Input.GetButtonDown("Fire2"))
        {
            //parryBox =  Instantiate(parryBox, firePoint.position, firePoint.rotation,Player.transform);
            parryBox.SetActive(true);
            StartCoroutine(disableParryBox());

            Boost();
            isBoost = true;
            StartCoroutine(boostIsActive());
        }


      
        else if(Input.GetButtonDown("Fire1")  && _DestroyMode.isDestroyMode)
        {

            bullet = Instantiate(misslePrefab, firePoint.position, firePoint.rotation);
            currentTimeBetweenBullets = 0;

        }

        //Overheating
        if (Input.GetButton("Fire1") && !_DestroyMode.isDestroyMode && !overHeating)
        {
            overHeatTime = overHeatTime + Time.deltaTime;
            
        }
        else if (!Input.GetButton("Fire1") && overHeatTime > 0 || overHeating)
        {
            overHeatTime = overHeatTime - (Time.deltaTime * coolDownFactor);
            //overHeatCounter = overHeatCounter - 1;

        }


        OverHeat(overHeatTime);
        overheatBar.SetOverheat(overHeatTime);





    }

    private void FixedUpdate()
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        firePoint.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg);

        //Animating
        animator.SetFloat("Horizontal", (mouse.x - transform.position.x));
        animator.SetFloat("Vertical", (mouse.y - transform.position.y));



        if (!isBoost)
        {


            // aCcounts for diagnoal movement. Makes it the same total velocity
            if (moveHorizontal != 0 && moveVertical != 0)
            {

                // characterRigidBody.velocity = new Vector2(moveHorizontal * movementSpeed * 0.707f, moveVertical * movementSpeed * 0.707f);
                characterRigidBody.AddForce(new Vector2(movementThrust * moveHorizontal * movementSpeed * 0.707f, movementThrust * moveVertical * movementSpeed * 0.707f));
            }

            else
            {
                //characterRigidBody.velocity = new Vector2(moveHorizontal * movementSpeed, moveVertical * movementSpeed);
                characterRigidBody.AddForce(new Vector2(movementThrust * moveHorizontal * movementSpeed, movementThrust * moveVertical * movementSpeed));
            }

        }

        //shooting
        if (Input.GetButton("Fire1") && (currentTimeBetweenBullets - timePerBullet) > 0 && !_DestroyMode.isDestroyMode && !overHeating)
        {

            bullet = Instantiate(airBulletPrefab, firePoint.position, firePoint.rotation);
            currentTimeBetweenBullets = 0;
            PushBack(mouse);


            // overHeatCounter = overHeatCounter + 1;

        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Wall myWall = collision.gameObject.GetComponent<Wall>();
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.gameObject.GetComponent<EnemyProjectile>();
        if (enemy != null && !enemy.isBlink)
        {
            Destroy(enemy.gameObject);

            PlayerDeath();

        }
        if (enemyProjectile != null)
        {
            Destroy(enemyProjectile.gameObject);

            PlayerDeath();

        }
        /*if (myWall != null)
        {
           // Boost();
            characterRigidBody.AddForce(new Vector2(),ForceMode2D.Impulse);
        }*/
    }

    /* void OnTriggerEnter2D(Collider2D collision)
     {
         Enemy enemy = collision.gameObject.GetComponent<Enemy>();

         if (enemy != null)
         {
             Destroy(enemy.gameObject);

             PlayerDeath();

         }
     }*/
    public void PlayerDeath()
    {
        lifeCount--;



        if (lifeCount <= 0)
        {
            SceneManager.LoadScene("Menu");


        }

    }

    IEnumerator disableParryBox()
    {
        yield return new WaitForSeconds(0.2f);
        parryBox.SetActive(false);
    }
    private void Boost()
    {

        characterRigidBody.AddForce((-Player.transform.position + firePoint.position) * boostForce, ForceMode2D.Impulse);


    }
    IEnumerator boostIsActive()
    {
        yield return new WaitForSeconds(0.25f);
        isBoost = false;
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
        yield return new WaitForSeconds(overHeatTime/coolDownFactor);
        overHeating = false;

    }
    private void PushBack(Vector3 mouse)
    {
        mouse.z = 0;
        fanDirection = new Vector2(mouse.x, mouse.y);
        
        characterRigidBody.AddForce( (-fanDirection + this.rb.position).normalized * airPushBackForce, ForceMode2D.Impulse);
        
    }



}
