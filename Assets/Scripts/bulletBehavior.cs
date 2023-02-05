using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior: MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody2D rb;
    public float speed = 30f;
    public GameObject bulletEnemy;
    public int bulletDamage = 100;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(bullet, 2f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();

        if (myWall != null)
        {
            //Instantiate(bulletEnemy, bullet.transform.position, bullet.transform.rotation);
            Destroy(bullet);

        }

        
        else if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
            Destroy(bullet);

        }
        else if (enemyProjectile != null)
        {
            Destroy(bullet);
        }

        else
        {
            //Destroy(bullet);
        }


    }
}
