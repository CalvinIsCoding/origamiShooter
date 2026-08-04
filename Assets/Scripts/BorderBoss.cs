using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Build;
using UnityEngine;

public class BorderBoss : Boss
{
    public HingeJoint2D[] segmentHinges = new HingeJoint2D[4];
    public GameObject[] firePoints = new GameObject[4];
    public GameObject centerOfEnemy;
    public Rigidbody2D mainBody;
    public FireBallProjectile fireBall;
    public Queue queue;
    public GameObject fireBallPrefab;
    public GameObject player;
    public float rotationSpeed;
    public float timeSinceLastShot;
    public float sweepShootingRate;
    public float slowShootingRate;
    public int numberOfSlowShots;
    public float tentacleRate;
    public float tentatcleSpeed;
    public float timeSinceLastTentacle;
    JointMotor2D curlMotor;
    JointMotor2D tentacleMotor;

    public bool attackOccurring;
    public bool rotationSet = false;
    public float myRotationAngle;
    public bool currentlyRotating;
    public int directionOfRotation;
    public bool directionDetermined;

    public int attackType;
    public bool preventAttackRepeat;

    public bool setUpForStartOfAttack;

    //sweepGunangles
    public int angleToStartSweep;
    public int widthOfSweep;
    public int lastAttack;
    public int numberOfAttacks = 3;
    



    void Start()
    {
        setUpForStartOfAttack = false;
        enemySpawn = FindAnyObjectByType<EnemySpawn>();
        //sweepShootingRate = 2f;
        tentatcleSpeed = 100f;
        tentacleRate = 10f;
        timeSinceLastShot = 0f;
        health = BossObject.health;
        timeSinceLastTentacle = 8f;
        sweepShootingRate = 0.1f;
        slowShootingRate = 0.5f;

        
      //  curlMotor.motorSpeed = -10f;

        
       // tentacleMotor.motorSpeed = 100f;
    }



    void FixedUpdate()
    {
        Rotate(rotationSpeed);
        if (attackOccurring == false || rotationSet == true) 
        {
           // Rotate(1f);
        }
        else 
        {
            //RotateUntil(myRotationAngle);
            //SweepGun(45,-90);
        }

        if (!attackOccurring)
        {
            //clockSprite.color = Color.white;

            //This if statement is here to prevent the boss from doing the same attack more than twice in a row. Two times is okay, but more than that is tedious.
            if (preventAttackRepeat)
            {
                Debug.Log("I'm cmoing");
                attackType = (attackType % numberOfAttacks) + 1;
                preventAttackRepeat = false;
            }
            else
            {
                attackType = UnityEngine.Random.Range(1, numberOfAttacks + 1);
            }
           

            switch (attackType)
            {
                case 1:
                    StartCoroutine(SweepingGunTelegraphedAttack());
                    
                    break;

                case 2:
                    StartCoroutine(SlowShooting());
                    break;

                case 3:
                    StartCoroutine(SpawnQueueBombs());
                    break;

            }

            if(lastAttack == attackType)
            {
                preventAttackRepeat = true;
            }

           
            lastAttack = attackType;
        }

        /*
         timeSinceLastShot += Time.deltaTime;

         if (timeSinceLastShot > sweepShootingRate)
         {
             ShootFireball();
             timeSinceLastShot = 0f;
         }
         */


        /*
         timeSinceLastShot += Time.deltaTime;

         if (timeSinceLastShot > tentacleRate)
         {
            StartCoroutine( SquidTentacle());
             timeSinceLastShot = 0f;
         }
         */

    }
    public IEnumerator SpawnQueueBombs()
    {
        attackOccurring = true;
        rotationSpeed = -100f;
        yield return new WaitForSeconds(1f);
        do
        {
            RotateUntil(30f, 125);
            yield return new WaitForEndOfFrame();
        }
        while (rotationSet == false);
        yield return new WaitForSeconds(0.25f);
        Instantiate(queue, firePoints[1].transform.position, firePoints[1].transform.rotation);
        
        yield return new WaitForSeconds(0.25f);
       
        do
        {
            RotateUntil(60f, 125);
            yield return new WaitForEndOfFrame();
        }
        while (rotationSet == false);

        Instantiate(queue, firePoints[2].transform.position, firePoints[2].transform.rotation);
        rotationSpeed = -100f;
        yield return new WaitForSeconds(5.0f);

        attackOccurring = false;
    }
    public IEnumerator SweepingGunTelegraphedAttack()
    {
        bool firstSweepDone = false;
        bool secondSweepDone = false;
        float timeSinceLoopStarted = 0f;
        attackOccurring = true;
        int sweeps;
        do
        {
            RotateUntil(45, 200);
            timeSinceLoopStarted += Time.deltaTime;
            if (timeSinceLoopStarted > 10f)
            {
                break;

            }
            yield return new WaitForEndOfFrame();
        }
        while (rotationSet == false);
        timeSinceLoopStarted = 0;
        yield return new WaitForSeconds(0.5f);
        do
        {
            firstSweepDone = SweepGunOnlyShoot(135);
            timeSinceLoopStarted += Time.deltaTime;

            //This is here as a failsafe to prevent an infinite loop
            if (timeSinceLoopStarted > 10f)
            {
                break;

            }
            yield return new WaitForEndOfFrame();
        }
        while (firstSweepDone == false);
        yield return new WaitForSeconds(0.5f);

        do
        {
            RotateUntil(45, 200);
            timeSinceLoopStarted += Time.deltaTime;
            if (timeSinceLoopStarted > 10f)
            {
                break;

            }
            yield return new WaitForEndOfFrame();
        }
        while (rotationSet == false);
        timeSinceLoopStarted = 0;
        yield return new WaitForSeconds(0.5f);
        do
        {
            firstSweepDone = SweepGunOnlyShoot(0);
            timeSinceLoopStarted += Time.deltaTime;

            //This is here as a failsafe to prevent an infinite loop
            if (timeSinceLoopStarted > 10f)
            {
                break;

            }
            yield return new WaitForEndOfFrame();
        }
        while (firstSweepDone == false);
        yield return new WaitForSeconds(0.5f);
        attackOccurring = false;
    }

    public IEnumerator SweepingGunQuickAttack()
    {
        bool firstSweepDone = false;
        bool secondSweepDone = false;
        float timeSinceLoopStarted = 0f;
        int sweeps;
        attackOccurring = true;


        do
        {
            firstSweepDone = SweepGunQuick(45, 45);
            timeSinceLoopStarted += Time.deltaTime;

            //This is here as a failsafe to prevent an infinite loop
            if (timeSinceLoopStarted > 10f)
            {
                break;

            }
            yield return new WaitForEndOfFrame();
        }
        while (firstSweepDone == false);
        yield return new WaitForSeconds(0.25f);
        rotationSpeed = 50f;
        yield return new WaitForSeconds(1f);
        do
        {
            secondSweepDone = SweepGunQuick(270, -45);
            timeSinceLoopStarted += Time.deltaTime;

            //This is here as a failsafe to prevent an infinite loop
            if (timeSinceLoopStarted > 10f)
            {
                break;

            }
            yield return new WaitForEndOfFrame();
        }
        while (secondSweepDone == false);



        yield return new WaitForSeconds(1f);
        attackOccurring = false;
    }
    public IEnumerator SlowShooting()
    {
        attackOccurring = true;
        rotationSpeed = 50f;
        for(int i = 0; i<4; i++)
        {
            ShootFireball();
            yield return new WaitForSeconds(1f);
        }
        rotationSpeed = -50f;
        for (int i = 0; i < 4; i++)
        {
            ShootFireball();
            yield return new WaitForSeconds(1f);
        }
        attackOccurring = false;


    }

    public IEnumerator CurlUp(float curlSpeed)
    {
        Debug.Log("Curl");
        

        foreach (HingeJoint2D hinge in segmentHinges)
        {
            hinge.motor = curlMotor;
            hinge.useMotor = true;
            
            

        }
        yield return new WaitForSeconds(5f);
        tentacleMotor.motorSpeed = tentatcleSpeed;
        foreach (HingeJoint2D hinge in segmentHinges)
        {
            hinge.motor = tentacleMotor;
            hinge.useMotor = false;



        }

    }
    public void Rotate(float speed)
    {
        mainBody.angularVelocity = speed;
    }
    public void ShootFireball()
    {
        foreach (GameObject firepoint in firePoints)
        {
            Instantiate(fireBallPrefab, firepoint.transform.position,firepoint.transform.rotation);
        }

    }
    public IEnumerator SquidTentacle()
    {
        Debug.Log("Tentacle");
        foreach (HingeJoint2D hinge in segmentHinges) {
            hinge.useMotor = true;
            

        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(CurlUp(-10f));

    }

    public bool SweepGunQuick(int startingAngle, int sweepAngle = 90)
    {
        int endingAngle = startingAngle + sweepAngle;
        if (endingAngle  < 0 && startingAngle > 0)
        {
            endingAngle += 360;
        }

        if(setUpForStartOfAttack == false)
        {
            RotateUntil(startingAngle, 200f);
            if (rotationSet == true)
            {
                setUpForStartOfAttack = true;
            }
        }
        
        
        if (setUpForStartOfAttack)
        {
            RotateUntil(endingAngle,100f);
            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot > sweepShootingRate)
            {
                ShootFireball();
                timeSinceLastShot = 0f;
            }
            if (rotationSet == true)
            {
                setUpForStartOfAttack = false;
                return true;
            }
        }
        
            
        
        return false;


        //Sweep  from right
        

        //sweep from left
    }
    public bool SweepGunOnlyShoot(int sweepAngle)
    {
        RotateUntil(sweepAngle, 75f);
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot > sweepShootingRate)
        {
            ShootFireball();
            timeSinceLastShot = 0f;
        }
        if (rotationSet == true)
        {
            //setUpForStartOfAttack = false;
            return true;
        }
        return false;
    }

    public void ShootLowRate()
    {
        
        if (numberOfSlowShots > 4)
        {
            rotationSpeed = -50f;
        }
        else
        {
            rotationSpeed = 50f;
        }

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot > slowShootingRate)
        {
            ShootFireball();
            timeSinceLastShot = 0f;
            numberOfSlowShots += 1;

        }
        

    }
    

    public void RotateUntil(float angle, float speed = 100f)
    {
        if (speed > 200)
        {
            speed = 200;
        }
        //else if(speed < 0)
        //{
        //    speed = speed * -1;
        //}
        float currentAngle;
        float rotationDelta;
        rotationSet = false;
        currentAngle = this.transform.rotation.eulerAngles.z;

       // Debug.Log("currentAngle" + currentAngle + " desired Angle " + angle);
   
            rotationDelta = currentAngle - angle;

        if (directionDetermined == false)
        {
            directionDetermined = true;
            if(Mathf.Abs(rotationDelta) >= 180)
            {
                directionOfRotation = (int)rotationDelta / Mathf.Abs((int)rotationDelta);
            }
            else if (rotationDelta < 0.01f && rotationDelta > -0.01f)
            {
                directionOfRotation = 1;
            }
            else
            {
                directionOfRotation = -(int)rotationDelta / Mathf.Abs((int)rotationDelta);
            }
            

        }


        //   Debug.Log("delta" + rotationDelta);

        if (Mathf.Abs(rotationDelta) > 2)
        {
            currentlyRotating = true;
            rotationSpeed = speed * directionOfRotation;
        }
        else
        {
            rb.SetRotation(angle);
            rotationSet = true;
            currentlyRotating = false;
            rotationSpeed = 0f;
            directionDetermined = false;
        }
        
       
    }
    public void DetermineRotationDirection()
    {
       // ((rotationDelta / Mathf.Abs(rotationDelta));
    }
   
    public void SpawnBombs()
    {
        Instantiate(queue, firePoints[0].transform.position, firePoints[0].transform.rotation);


    }
public void OnCollisionEnter2D(Collision2D collision)
    {
        Queue _queue = collision.gameObject.GetComponent<Queue>();
        if (_queue != null) {

            Debug.Log("collided");
            TakeDamage(10);
            Destroy(_queue.gameObject);
        }
        
    }

}
