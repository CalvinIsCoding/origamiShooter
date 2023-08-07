using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject missile;
    public GameObject smallExplosion;

    public Rigidbody2D rb;
    public float speed = 5f;
    public GameObject bulletEnemy;
    public int bulletDamage = 100;
    public float knockBack = 10f;

    void Start()
    {

        rb.velocity = transform.right * speed;
        Destroy(missile, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        AirBullet collidedBullet = collision.GetComponent<AirBullet>();

        if (myWall != null)
        {
            //Instantiate(bulletEnemy, bullet.transform.position, bullet.transform.rotation);
            Destroy(missile);
            Instantiate(smallExplosion, missile.transform.position, missile.transform.rotation);

        }


        else if (enemy != null)
        {
            // 
            Destroy(missile);
            enemy.Die();
            Instantiate(smallExplosion, missile.transform.position, missile.transform.rotation);

            //Destroy(bullet);

        }

        else if (enemyProjectile != null)
        {
            //Destroy(missle);
        }

        else
        {
            //Destroy(bullet);
        }


    }
}
