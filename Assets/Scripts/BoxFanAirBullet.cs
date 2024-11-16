using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFanAirBullet: MonoBehaviour
{
    public GameObject boxFanAirBullet;

    public Rigidbody2D rb;
    public float speed;
    public GameObject bulletEnemy;
    public GameObject source;
    public int bulletDamage = 100;
    public float knockBack = 5f;

    public SpriteRenderer boxFanAirBulletSprite;
    void Start()
    {

        rb.velocity = transform.right * speed;
        Destroy(boxFanAirBullet, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        //BoxFanAirBullet collidedBullet = collision.GetComponent<BoxFanAirBullet>();
        PlayerController playerController = collision.GetComponent<PlayerController>();

        if (myWall != null)
        {
            Instantiate(source, boxFanAirBullet.transform.position, boxFanAirBullet.transform.rotation);
            //Destroy(bullet);
            boxFanAirBulletSprite.enabled = false;
        }

        
        else if (enemy != null )
        {
            // 
           // enemy.Push(knockBack,rb,boxFanAirBullet);
            //Destroy(bullet);

        }

        else if (playerController != null)
        {
            playerController.Push(knockBack,rb,boxFanAirBullet );
        }
        
        else if (enemyProjectile != null)
        {
            Destroy(boxFanAirBullet);
        }

        else
        {
            //Destroy(bullet);
        }


    }
}
