using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet: MonoBehaviour
{
    public GameObject airBullet;

    public Rigidbody2D rb;
    public float speed = 30f;
    public GameObject bulletEnemy;
    public GameObject source;
    public int bulletDamage = 100;
    public float knockBack = 10f;

    public SpriteRenderer airBulletSprite;
    void Start()
    {

        rb.velocity = transform.right * speed;
        Destroy(airBullet, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        AirBullet collidedBullet = collision.GetComponent<AirBullet>();

        if (myWall != null)
        {
            Instantiate(source, airBullet.transform.position, airBullet.transform.rotation);
            //Destroy(bullet);
            airBulletSprite.enabled = false;
        }

        
        else if (enemy != null )
        {
            // 
            enemy.Push(knockBack,rb,airBullet);
            //Destroy(bullet);

        }
        
        else if (enemyProjectile != null)
        {
            Destroy(airBullet);
        }

        else
        {
            //Destroy(bullet);
        }


    }
}
