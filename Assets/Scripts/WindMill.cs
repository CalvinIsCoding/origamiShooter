using System.Collections;
using System.Linq;
using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsShape;

public class WindMill : Boss
{
    public Rigidbody2D windMillArmsRb;
    public GameObject loafOfBread;
    public Rigidbody2D loafOfBreadRigidbody;
    public GameObject windMillArm;
    public Transform firePoint;
    public float lastRotation;
    public int numberOfBreadLoavesInHolster;
    public Vector2 playerDirection;
    public Rigidbody2D playerRb;
    public float shootingBreadCooldownTotalTime;
    public float shootingBreadCooldown;
    public PlayerController playerController;

    private float minimumDistanceFromFire;
    public ContactFilter2D contactFilter = new ContactFilter2D();

    public float millMovementForce;
    public float dashSpeed;
    public int numberOfDashes;

    public bool attackOccurring;
    public int attackType;
    public Vector2 center;

    public FirePlace firePlace;
    public float delayTillCornerLight;

    public bool invulernable;
    public bool dashAttackOccurring;


    void Start()
    {
        dashAttackOccurring = false;
        minimumDistanceFromFire = 0.4f;
        shootingBreadCooldownTotalTime = 0.5f;

        firePlace = FindAnyObjectByType<FirePlace>();

        enemySpawn = FindAnyObjectByType<EnemySpawn>();
        playerController = FindAnyObjectByType<PlayerController>();
        playerRb = playerController.GetComponent<Rigidbody2D>();
        millMovementForce = 2.75f;
        dashSpeed = 6.5f;
        attackOccurring = false;
        numberOfDashes = 3;
        center = Vector2.zero;
       //LayerMask mask = LayerMask.GetMask("FirePlace");
        //contactFilter.SetLayerMask(mask);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MillGrain();
        /*
        shootingBreadCooldown += Time.fixedDeltaTime;
        if(numberOfBreadLoavesInHolster > 2 && shootingBreadCooldown > shootingBreadCooldownTotalTime)
        {
            ShootBread();
            shootingBreadCooldown = 0f;
        }
        */
        


        if (!attackOccurring )
        {
            
            switch (attackType)
            {
                

                case 1:
                    StartCoroutine(ChaseOpponentAttack());
                    break;

                case 2:
                    StartCoroutine(BreadAttack());
                    break;

            }
            attackType = Random.Range(1, 3);
        }

        if (firePlace.cornerLit == false && delayTillCornerLight >= 1f)
        {
            StartCoroutine(firePlace.LightCorner());
            delayTillCornerLight = 0;
        }
        delayTillCornerLight += Time.fixedDeltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AirBullet bullet = collision.GetComponent<AirBullet>();
        FirePlace fireplaceCollider = collision.GetComponentInParent<FirePlace>();

        Debug.Log("collision " + collision);
        if (bullet != null)
        {
            windMillArmsRb.AddTorque(0.8f);
        }

        if (fireplaceCollider != null)
        {
            StopCoroutine(BreadAttack());
            StopCoroutine(ChaseOpponentAttack());
            StartCoroutine(DashAttack());
        }


    }

    
    public void MillGrain()
    {
        if (windMillArm.transform.rotation.z > 0 && lastRotation < 0)
        {
            LoadBreadHolster();
        }
        
        lastRotation = windMillArm.transform.rotation.z;
    }

    public void LoadBreadHolster()
    {
        numberOfBreadLoavesInHolster++;
    }

    public void ShootBread()
    {
        playerDirection = playerRb.position - rb.position;
        DetermineFirepointDirection(playerDirection);
        numberOfBreadLoavesInHolster--;
        Instantiate(loafOfBread,firePoint.position,firePoint.rotation);
        loafOfBreadRigidbody = loafOfBread.GetComponent<Rigidbody2D>();
        loafOfBreadRigidbody.AddForceAtPosition(playerDirection * 10f, loafOfBreadRigidbody.position,ForceMode2D.Impulse);
    }
    public void DetermineFirepointDirection(Vector2 direction)
    {
        float angleOfFirePoint = Mathf.Atan2(direction.y, direction.x);
        firePoint.rotation = Quaternion.Euler(0, 0, angleOfFirePoint * Mathf.Rad2Deg);
        firePoint.transform.localPosition = new Vector2(Mathf.Cos(angleOfFirePoint) * 2f, Mathf.Sin(angleOfFirePoint) * 2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(rb.position, minimumDistanceFromFire);
    }
    public Vector2 DetermineDirection()
    {
        Collider2D[] nearEntity = new Collider2D[5];
        
        int objectsDetected = Physics2D.OverlapCircle(rb.position, minimumDistanceFromFire, contactFilter, nearEntity);

        Vector2 direction = new Vector2(0,0);

        //The box fan should try to avoid the fire
        if (objectsDetected > 0)
        {
            direction = new Vector2(0, 0) - rb.position;

           // angleOfFirePoint = Mathf.PI + Mathf.Atan2(direction.y, direction.x);
            //rb.rotation = angleOfFirePoint * (180 / Mathf.PI);
        }
        else
        {
            direction = playerRb.position - rb.position;
        }
         /*
        if (direction.magnitude > farFromPlayerDistance)
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
            angleOfFirePoint = Mathf.Atan2(direction.y, direction.x);

            // rb.rotation = angleOfFirePoint * (180 / Mathf.PI);
        }
         */


        return direction;
    }
    public void Dash(Vector2 dashDirection, float force)
    {

        rb.AddForce(dashDirection.normalized * force, ForceMode2D.Impulse);
    }

    IEnumerator DashAttack()
    {
        Debug.Log("Dash Attack");
        attackOccurring = true;
        dashAttackOccurring = true;
        yield return new WaitForSeconds(0.25f);
        Dash(playerRb.position - rb.position, dashSpeed);
        yield return new WaitForSeconds(0.7f);

        for (int i = 0; i < numberOfDashes; i++)
        {

            Dash(rb.position - playerRb.position, dashSpeed);
            yield return new WaitForSeconds(0.6f);
            Dash(DetermineDirection(),dashSpeed);
            yield return new WaitForSeconds(0.7f);
            
            




        }
        //Rest();
        yield return new WaitForSeconds(1f);
        attackOccurring = false;
        dashAttackOccurring = false;
    }

    IEnumerator ChaseOpponentAttack()
    {
        Debug.Log("Chase Opponents Attack");
        attackOccurring = true;
        for (int i = 0;i < 250;i++) 
        {
            rb.AddForceAtPosition(DetermineDirection() * millMovementForce, rb.position);
            yield return new WaitForFixedUpdate();
        }
        attackOccurring = false;

    }

    IEnumerator BreadAttack()
    {
        Debug.Log("Bread Attack");
        attackOccurring = true;
        for (int i = 0; i < numberOfBreadLoavesInHolster;i++)
        {
            ShootBread();
            yield return new WaitForSeconds(0.1f);
        }
        attackOccurring = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided " + collision);
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null) 
        {
            player.PlayerDeath(false, 2);
            Vector2 oppositeDirectionOfPlayer =  rb.position - playerRb.position;
            if(dashAttackOccurring == false)
            {
                Dash(oppositeDirectionOfPlayer, collision.relativeVelocity.magnitude + 1);
            }
            
        }
        
    }

}
