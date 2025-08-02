using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentCircles : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRb;
    public BoxCollider2D bc;
    public SpriteRenderer percentDotSprite;
    public Transform dotTransform1;
    public Transform dotTransform2;
    [SerializeField]
    private Enemy _enemy;

    public float angle;
    public float dAngle;
    public Rigidbody2D rb;
    public GameObject dot;
    //Sprites
    public Sprite N;
    public Sprite NE;
    public Sprite E;


    private float speed;
    private float lastTime;
    private float timer;
    private float spawnDelayTime = 0.8f;
    private float percentDotMovementForce;
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

        speed = 1f;

        percentDotMovementForce = 0.8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (timer >= 1.5f)
        {   
            if(!_enemy.isBlown)
            {
                Vector2 direction = playerRb.position - rb.position;
                angle = Mathf.Atan2(direction.y, direction.x);
                rb.rotation = 90 + (angle * (180 / Mathf.PI));
                rb.AddForceAtPosition(direction.normalized * (percentDotMovementForce), this.rb.position);
            }
                
        }
        timer += Time.fixedDeltaTime;
    }

}
