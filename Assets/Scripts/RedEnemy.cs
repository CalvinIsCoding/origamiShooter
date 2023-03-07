using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject player;
    public BoxCollider2D bc;
    public SpriteRenderer redPlaneSprite;
    public float angle;
    //public Rigidbody2D rb;

    public bool isParried;
    public GameObject parryExplosion;

    private float speed;
    private float lastTime;
    private float spawnDelayTime = 0.8f;
    private bool spriteToggle;
    private int blinks = 6;

    void Start()
    {
        bc.enabled = false;

        spriteToggle = false;
        isParried = false;
        StartCoroutine(Blink());

        player = GameObject.FindWithTag("Player");

        lastTime = Time.time;

        speed = 0f;


    }

    void Update()
    {
        if (lastTime - Time.time < -spawnDelayTime && !bc.enabled)
        {

            bc.enabled = true;
            speed = 0.5f;
        }



        if (!isParried)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            angle = Mathf.Atan2(direction.y, direction.x);
            this.transform.rotation = Quaternion.Euler(0f, 0f, angle * (180 / Mathf.PI));

            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Wall myWall = collision.gameObject.GetComponent<Wall>();
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if ((myWall != null && (lastTime - Time.time < (-spawnDelayTime - 0.5))))
        {

            
            if (isParried)
            {
                Instantiate(parryExplosion, bc.transform.position, bc.transform.rotation);
            }
            Destroy(this.gameObject);


        }



        else
        {

        }


    }

    IEnumerator Blink()
    {
        for (int i = 0; i < blinks; i++)
        {
            redPlaneSprite.enabled = spriteToggle;
            spriteToggle = !spriteToggle;
            yield return new WaitForSeconds(spawnDelayTime / blinks);
        }

    }
    public void Parry(Quaternion reflectedDirection)
    {

        isParried = true;
        angle = reflectedDirection.eulerAngles.z;

        speed = 1.5f;
    }
}
