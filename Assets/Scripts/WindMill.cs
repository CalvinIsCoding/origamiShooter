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


    void Start()
    {
        minimumDistanceFromFire = 0.45f;
        shootingBreadCooldownTotalTime = 0.5f;

        enemySpawn = FindAnyObjectByType<EnemySpawn>();
        playerController = FindAnyObjectByType<PlayerController>();
        playerRb = playerController.GetComponent<Rigidbody2D>();
        millMovementForce = 17.75f;
       //LayerMask mask = LayerMask.GetMask("FirePlace");
        //contactFilter.SetLayerMask(mask);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MillGrain();
        shootingBreadCooldown += Time.fixedDeltaTime;
        if(numberOfBreadLoavesInHolster > 2 && shootingBreadCooldown > shootingBreadCooldownTotalTime)
        {
            ShootBread();
            shootingBreadCooldown = 0f;
        }
        rb.AddForceAtPosition(DetermineDirection() * millMovementForce, rb.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AirBullet bullet = collision.GetComponent<AirBullet>();

        if (bullet != null)
        {
            windMillArmsRb.AddTorque(0.8f);
        }

    }
    public void MillGrain()
    {
        if (windMillArm.transform.rotation.z > 0 && lastRotation < 0)
        {
            numberOfBreadLoavesInHolster++;
        }
        
        lastRotation = windMillArm.transform.rotation.z;
    }

    public void LoadBreadHolster()
    {

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
        firePoint.transform.localPosition = new Vector2(Mathf.Cos(angleOfFirePoint) * 1f, Mathf.Sin(angleOfFirePoint) * 1f);
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
}
