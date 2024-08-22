using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemy : MonoBehaviour
{
    [SerializeField] CircleCollider2D mainBody;
    [SerializeField] CircleCollider2D hole;
    public GameObject backHitBox;
    Vector2 playerDirection;
    Vector2 enemyFacingDirection;
    public GameObject player;
    public GameObject cEnemyObject;
    public Rigidbody2D playerRb;
    public Rigidbody2D rb;
    private float angleToFacePlayerRadians;
    private float angleToFacePlayerDegrees;
    private float torqueDirection;
    private float torqueForce;
    private float baseTorqueForce;
    private float cMovementForce;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        Vector2 direction = playerRb.position - rb.position;
        angleToFacePlayerRadians = Mathf.Atan2(direction.y, direction.x);
        rb.rotation = 180 + (angleToFacePlayerRadians * (180 / Mathf.PI));
        torqueDirection = -1f;
        Instantiate(backHitBox, this.transform);
        baseTorqueForce = 0.10f * rb.mass * Vector3.Magnitude(cEnemyObject.transform.localScale);
        cMovementForce = 0.1f * rb.mass * rb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 playerDirection = playerRb.position - rb.position;
        Vector2 playerRelativePosition = this.transform.InverseTransformPoint(player.transform.position);

        if (playerRelativePosition.y >= 0)
        {
            torqueDirection = -1;
        }
        else
        {
            torqueDirection = 1;
        }
        calculateTorque(playerDirection);



        //Vector2 direction = playerRb.position - rb.position;
        //angle = Mathf.Atan2(direction.y, direction.x);
        //rb.rotation = angle * (180 / Mathf.PI);
        rb.AddForceAtPosition(-transform.right * cMovementForce, this.rb.position);
        /*if (Mathf.Abs(rb.rotation - angleToFacePlayerDegrees) < 180f)
        {
            torqueDirection = 1; 
        }
        else
        {
            torqueDirection = -1;
        }
*/

        rb.AddTorque(torqueDirection * torqueForce);
    }
    private void calculateTorque(Vector2 direction)
    {
        enemyFacingDirection = new Vector2(Mathf.Cos(this.transform.eulerAngles.z), Mathf.Sin(this.transform.eulerAngles.z));
        torqueForce = baseTorqueForce * Mathf.Pow((Vector2.Dot(enemyFacingDirection, direction) + 1) / 2 , 2);
        // Mathf.Sin(this.transform.eulerAngles.z);
        //Debug.Log(torqueForce);
        //Debug.Log("playerDirection: " + direction);

        // torqueForce = 
    }
    public void grow()
    {
        Debug.Log("I'm growing");
        Vector3 scaleChange = new Vector2(0.005f,0.005f);
        cEnemyObject.transform.localScale += scaleChange;

        if(rb.drag > 2f)
        {
            rb.drag -= 3f;

        }
        

        baseTorqueForce = 0.10f * rb.mass * Vector3.Magnitude(cEnemyObject.transform.localScale);
        cMovementForce = 0.3f * rb.mass * rb.drag;

    }
    

}
