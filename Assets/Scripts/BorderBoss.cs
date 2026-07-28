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
    public GameObject fireBallPrefab;
    public GameObject player;
    public float rotationSpeed;
    public float timeSinceLastShot;
    public float shootingRate;
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

    public bool setUpForStartOfAttack;



    void Start()
    {
        setUpForStartOfAttack = false;
        enemySpawn = FindAnyObjectByType<EnemySpawn>();
        //shootingRate = 2f;
        tentatcleSpeed = 100f;
        tentacleRate = 10f;
        timeSinceLastShot = 0f;
        health = 100;
        timeSinceLastTentacle = 8f;

        
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
            SweepGun(45,-90);
        }
        
       /*
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot > shootingRate)
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

    public void SweepGun(int startingAngle, int sweepAngle = 90)
    {
        int endingAngle = startingAngle + sweepAngle;
        if (endingAngle  < 0 && startingAngle > 0)
        {
            endingAngle += 360;
        }

        if(setUpForStartOfAttack == false)
        {
            RotateUntil(startingAngle);
            if (rotationSet == true)
            {
                setUpForStartOfAttack = true;
            }
        }
        
        
        if (setUpForStartOfAttack)
        {
            RotateUntil(endingAngle);
            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot > shootingRate)
            {
                ShootFireball();
                timeSinceLastShot = 0f;
            }
            if (rotationSet == true)
            {
                setUpForStartOfAttack = false;
            }
        }
        
            
        



        //Sweep  from right
        

        //sweep from left
    }

    public void RotateUntil(float angle)
    {
        float currentAngle;
        float rotationDelta;
        rotationSet = false;
        currentAngle = this.transform.rotation.eulerAngles.z;

        Debug.Log("currentAngle" + currentAngle + " desired Angle " + angle);
   
            rotationDelta = currentAngle - angle;

        if (directionDetermined == false)
        {
            directionDetermined = true;
            if(Mathf.Abs(rotationDelta) >= 180)
            {
                directionOfRotation = (int)rotationDelta / Mathf.Abs((int)rotationDelta);
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
            rotationSpeed = 150 * directionOfRotation;
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
   

public void OnCollisionEnter2D(Collision2D collision)
    {
        FireBallEnemy fireBall = collision.gameObject.GetComponent<FireBallEnemy>();
        if (fireBall != null) {

            Debug.Log("collided");
            TakeDamage(10);
            Destroy(fireBall.gameObject);
        }
        
    }

}
