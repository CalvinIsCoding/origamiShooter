using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Source : MonoBehaviour
{
    public GameObject source;

    public Rigidbody2D rb;
    public float timeAlive;
    //public float speed = 30f;
   // public GameObject bulletEnemy;
    //public GameObject source;
    //public int bulletDamage = 100;
    public float knockBack;

    //public SpriteRenderer airBulletSprite;
    void Start()
    {

        //rb.velocity = transform.right * speed;
        Destroy(source, timeAlive);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        AirBullet collidedBullet = collision.GetComponent<AirBullet>();

       


        if (enemy != null)
        {
            // 
            enemy.rb.AddForce(( enemy.transform.position - this.transform.position) * knockBack);
            //Destroy(bullet);

        }

       


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
            //enemy.Push(knockBack, rb, source, rb.linearVelocity);
            enemy.rb.AddForce((enemy.transform.position - this.transform.position) * knockBack);
            //Destroy(bullet);

        }




    }
}
