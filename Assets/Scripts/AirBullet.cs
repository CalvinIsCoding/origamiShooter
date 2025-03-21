using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet: MonoBehaviour
{
    public GameObject airBullet;

    public Rigidbody2D rb;
    public float speed;
    public GameObject bulletEnemy;
    public GameObject source;
    public int bulletDamage = 100;
    public float knockBack = 0.8f;
    public ShopItemSO fanBlades;

    public SpriteRenderer airBulletSprite;

    //shrink bullets
    private int shrinkFrames = 30;
    private float currentScale;
    private float shrinkTime;
    void Start()
    {

        rb.velocity = transform.right * speed;
        Destroy(airBullet, 1.0f);
        knockBack = 15f;
        shrinkTime = 0.5f;
        
        currentScale = 0.4f;
        StartCoroutine(ShrinkBullets());
    }
    private void Update()
    {
        knockBack = 15f + (fanBlades.numberPurchased * 7.5f);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        AirBullet collidedBullet = collision.GetComponent<AirBullet>();
        Boss boss = collision.GetComponent<Boss>();

        if (myWall != null)
        {
            Instantiate(source, airBullet.transform.position, airBullet.transform.rotation);
            Destroy(collidedBullet);
            airBulletSprite.enabled = false;
        }

        
        else if (enemy != null )
        {
            // 
            enemy.Push(knockBack/2f,rb,airBullet,rb.velocity);
            //Destroy(airBullet);

        }
        if ( boss != null)
        {
            boss.Push(knockBack/2f, rb, airBullet);
        }
        
        if (enemyProjectile != null)
        {
            Destroy(airBullet);
        }

        else
        {
            //Destroy(bullet);
        }


    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        AirBullet collidedBullet = collision.GetComponent<AirBullet>();
        Boss boss = collision.GetComponent<Boss>();

        if (myWall != null)
        {
            Instantiate(source, airBullet.transform.position, airBullet.transform.rotation);
            //Destroy(bullet);
            airBulletSprite.enabled = false;
        }


        else if (enemy != null)
        {
            // 
            enemy.Push(knockBack/2f, rb, airBullet, rb.velocity);
            //Destroy(airBullet);

        }
        if (boss != null)
        {
            boss.Push(knockBack/2f, rb, airBullet);
        }

        if (enemyProjectile != null)
        {
            Destroy(airBullet);
        }

        else
        {
            //Destroy(bullet);
        }


    }
    IEnumerator ShrinkBullets()
    {
        for (int i = 1; i < shrinkFrames; i++)
        {
            currentScale -= ((0.07f * (1f/i)));
           
            airBullet.transform.localScale = Vector2.one * currentScale;
            yield return new WaitForSeconds(shrinkTime / shrinkFrames);
        }
        

    }
}
