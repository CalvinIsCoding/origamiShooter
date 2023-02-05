using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemyController : MonoBehaviour
{


    //public GameObject enemy;
    public GameObject player;
    public CircleCollider2D bc;

    //public Rigidbody2D rb;

    public float speed;
    public Vector3 playerPosition;
    public Vector3 direction;
    public float angle;

    public bool isParried;
    public GameObject parryExplosion;

    private float lastTime;
    private float spawnDelayTime = 0.8f;
    private bool spriteToggle;
    private int blinks = 6;
    public SpriteRenderer bulletEnemySprite;

 
    void Start()
    {
        bc.enabled = false;

        spriteToggle = false;
        StartCoroutine(Blink());
        lastTime = Time.time;

        player = GameObject.FindWithTag("Player");
        
        speed = 0f;
        isParried = false;

    }



    void Update()
    {

        if (lastTime - Time.time < -spawnDelayTime && !bc.enabled)
        {

            bc.enabled = true;
            playerPosition = player.transform.position;
            direction = playerPosition - this.transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * (180 / Mathf.PI);
            Debug.Log("my collider is enabled");
            speed = 1.5f;
            
        }



        this.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        
    }

    public void Parry(Quaternion reflectedDirection)
    {

        isParried = true;
        angle = reflectedDirection.eulerAngles.z;
        
        speed = 1.5f;
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        Wall myWall = collision.gameObject.GetComponent<Wall>();
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if ((myWall != null && (lastTime - Time.time < (-spawnDelayTime - 0.5))) || isParried)
        {
           
            Debug.Log("I'm touching a wall");
            if (isParried)
            {
                Instantiate(parryExplosion, bc.transform.position, bc.transform.rotation);
            }
            Destroy(this.gameObject);
            

        }


        else if (enemy != null)
        {
            enemy.TakeDamage(100);
            


        }

        else
        {
            
        }


    }
    IEnumerator Blink()
    {
        for (int i = 0; i < blinks; i++)
        {
            bulletEnemySprite.enabled = spriteToggle;
            spriteToggle = !spriteToggle;
            yield return new WaitForSeconds(spawnDelayTime / blinks);
        }

    }
}
