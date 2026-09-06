using System.Collections;
using UnityEngine;

public class PaperFan : Boss
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public PlayerController playerController;
    public GameObject bigAirBullet;
    public GameObject smallAirBullet;
    public bool setUpForStartOfAttack;
    public float timeSinceLastShot;
    public bool attackOccurring;
    public int attackType;
    public bool preventAttackRepeat;
    public int numberOfAttacks;
    public int lastAttack;
    public Transform firePoint;
    public float airPushBackForce;
    public Vector2 fanDirection;
    public Rigidbody2D playerRb;
    public Vector2 playerDirection;
    public float timeBetweenSlowBullets;
    public float timeBetweenFastBullets;
  //  public EnemySpawn enemySpawn;



    void Start()
    {
        setUpForStartOfAttack = false;
        enemySpawn = FindAnyObjectByType<EnemySpawn>();
        playerController = FindAnyObjectByType<PlayerController>();
        playerRb = playerController.GetComponent<Rigidbody2D>();
        //sweepShootingRate = 2f;

        timeSinceLastShot = 0f;
        health = BossObject.health;
        timeBetweenSlowBullets = 0.8f;
        timeBetweenFastBullets = 0.1f;
        airPushBackForce = 0.2f;
        numberOfAttacks = 3;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        playerDirection = playerRb.position - rb.position;
        
        if (!attackOccurring)
        {
            //clockSprite.color = Color.white;

            //This if statement is here to prevent the boss from doing the same attack more than twice in a row. Two times is okay, but more than that is tedious.
            if (preventAttackRepeat)
            {
                
                attackType = (attackType % numberOfAttacks) + 1;
                preventAttackRepeat = false;
            }
            else
            {
                attackType = UnityEngine.Random.Range(3, numberOfAttacks + 1);
            }


            //This logic here is to make the bombs spawn more often so the player doesn't get stuck dodging bullets for a few years.


            switch (attackType)
            {
                case 1:
                    Debug.Log("bslow gust");
                    StartCoroutine(SlowBigGustsAttack());
                    
                    break;

                case 2:
                    // StartCoroutine(SlowShooting());
                    Debug.Log("fast gust");
                    StartCoroutine(FastBigGustsAttack());

                    break;

                case 3:
                    Debug.Log("swim");
                    StartCoroutine(Swim());
                    break;



            }

            if (lastAttack == attackType)
            {
                preventAttackRepeat = true;
            }


            lastAttack = attackType;
        }

    }
    public void PickDestination()
    {
        Vector2 destinationPosition = new Vector2(Random.Range(enemySpawn.xMin, enemySpawn.xMax), Random.Range(enemySpawn.yMin, enemySpawn.yMax));
        fanDirection = rb.position - destinationPosition;
    }

   
    public void PushBack()
    {

        //fanDirection = new Vector2(playerPosition.x, playerPosition.y);\
        //fanDirection = new Vector2(firePoint.position.x, firePoint.position.y);

        rb.AddForce((-fanDirection + this.rb.position).normalized * airPushBackForce, ForceMode2D.Impulse);

    }

    public void ShootSmallAirBullet()
    {
        Instantiate(smallAirBullet, firePoint.position, firePoint.rotation);
    }
    public void ShootBigAirBullet()
    {
        Instantiate(bigAirBullet, firePoint.position, firePoint.rotation);
    }
    public IEnumerator SlowBigGustsAttack()
    {
        attackOccurring = true;
        for (int i = 0; i < 3; i++)
        {
            float angleOfFirePoint = Mathf.Atan2(playerDirection.y, playerDirection.x);
            firePoint.rotation = Quaternion.Euler(0, 0, angleOfFirePoint * Mathf.Rad2Deg) ;
            firePoint.transform.localPosition = new Vector2(Mathf.Cos(angleOfFirePoint) * 0.5f, Mathf.Sin(angleOfFirePoint) * 0.5f);
            ShootBigAirBullet();
            yield return new WaitForSeconds(timeBetweenSlowBullets);
        }

        attackOccurring = false;


    }

    public IEnumerator FastBigGustsAttack()
    {
        attackOccurring = true;
        for (int i = 0; i < 3; i++)
        {
            float angleOfFirePoint = Mathf.Atan2(playerDirection.y, playerDirection.x);
            firePoint.rotation = Quaternion.Euler(0, 0, angleOfFirePoint * Mathf.Rad2Deg);
            firePoint.transform.localPosition = new Vector2(Mathf.Cos(angleOfFirePoint) * 0.5f, Mathf.Sin(angleOfFirePoint) * 0.5f);
            ShootBigAirBullet();
            yield return new WaitForSeconds(timeBetweenFastBullets);
        }
        attackOccurring = false;
    }
    public IEnumerator Swim()
    {
        //needs to stop around the location it wants
        attackOccurring = true;
        PickDestination();
        for(int i = 0;i < 10;i++)
        {
            PushBack();
            yield return new WaitForSeconds(0.2f);
        }
        attackOccurring = false;

    }

}
