using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    public GameObject source;

    public Rigidbody2D rb;
    //public float speed = 30f;
   // public GameObject bulletEnemy;
    //public GameObject source;
    //public int bulletDamage = 100;
    public float knockBack;

    //public SpriteRenderer airBulletSprite;
    void Start()
    {

        //rb.velocity = transform.right * speed;
        Destroy(source, 0.025f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        AirBullet collidedBullet = collision.GetComponent<AirBullet>();

       


        if (enemy != null)
        {
            // 
            enemy.Push(knockBack, rb, source);
            //Destroy(bullet);

        }

       


    }
}
