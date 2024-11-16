using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class percent : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRb;
    public BoxCollider2D bc;
    public SpriteRenderer percentSprite;
    private Vector2 dotTransform1;
    private Vector2 dotTransform2;

    public float angle;
    public float dAngle;
    public Rigidbody2D rb;
    public GameObject dot1;
    public GameObject dot2;
    //Sprites
    public Sprite N;
    public Sprite NE;
    public Sprite E;


    private float speed;
    private float lastTime;
    private float timer;
    private float spawnDelayTime = 0.8f;
    private float planeMovementForce;
    private bool done;

    // private bool spriteToggle;
    //private int blinks = 6;

    public bool isBlink;

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

        speed = 0.1f;

        planeMovementForce = 0.75f;
        dotTransform1 = new Vector2(transform.position.x + 0.05f, this.transform.position.y - 0.05f);
        dotTransform2 = new Vector2(transform.position.x - 0.05f, this.transform.position.y + 0.05f);

        //rb.constraints = RigidbodyConstraints2D.FreezePosition;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = 1f;
        rb.angularDrag = 0.15f;

        
        done = false;
        Instantiate(dot1, dotTransform1, Quaternion.identity);
        Instantiate(dot2, dotTransform2, Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (timer >= 1.5f)
          {
            //Debug.Log( angle);
            angle = (rb.transform.localEulerAngles.z / 180) * Mathf.PI;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(-speed * Mathf.Sin(angle), speed * Mathf.Cos(angle)),ForceMode2D.Impulse);
          }
         /* if (timer >= 1.5f)
          {
       float torqueAmount = 0.10f;
            rb.AddTorque(torqueAmount, ForceMode2D.Force);
            Debug.Log("Applying torque: " + torqueAmount + ", Angular Velocity: " + rb.angularVelocity);*/
            /* 
             rb.constraints = RigidbodyConstraints2D.FreezeRotation;
             rb.rotation = 1;
             rb.AddForceAtPosition(new Vector2(0f, 10f), this.transform.position);
             done = true;*/
       // }

        timer += Time.fixedDeltaTime;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wall myWall = collision.gameObject.GetComponent<Wall>();
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 contactCoordinates = contact.point;
        Debug.Log(contactCoordinates);
        if (myWall != null)
        {
            //speed = speed * -1;
            if (contactCoordinates.x >= 2.0 || contactCoordinates.y >= 0.95)
            {
                speed = -1 * Mathf.Abs(speed);
            }
            else if (contactCoordinates.x <= -2.2 || contactCoordinates.y <= -1.3)
            {
                speed = 1 * Mathf.Abs(speed);
            }
        }
    }
}
