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
    public ShopItemSO biggerAir;

    public SpriteRenderer airBulletSprite;

    //shrink bullets
    private int shrinkFrames = 30;
    private float DefaultAirBulletScale;
    private float currentAirBulletScale;
    private float shrinkTime;
    void OnEnable()
    {

        rb.velocity = transform.right * speed;
        //Destroy(airBullet, 1.0f);
        //Object Pooling
        
        knockBack = 15f + (fanBlades.numberPurchased * 7.5f);
        shrinkTime = 0.5f;
        DefaultAirBulletScale = 0.4f + (biggerAir.numberPurchased * 0.1f);
        currentAirBulletScale = DefaultAirBulletScale;
        StartCoroutine(ShrinkBullets());
        //StartCoroutine(DeactivateBullets());
    }
    private void Update()
    {
        
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
            //Destroy(collidedBullet);
            //Object pooling bullet. Send back to cache
            airBullet.SetActive(false);
            //airBulletSprite.enabled = false;
        }

        
        else if (enemy != null )
        {
            // 
            enemy.Push(knockBack/2f,rb,airBullet,rb.velocity);
            //airBullet.SetActive(false);
            // Destroy(airBullet);

        }
        if ( boss != null)
        {
            boss.Push(knockBack/2f, rb, airBullet);
        }
        
        if (enemyProjectile != null)
        {
            //Destroy(airBullet);
            airBullet.SetActive(false);
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
            airBullet.SetActive(false);
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
            //Destroy(airBullet);
            airBullet.SetActive(false);
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
            currentAirBulletScale -= ((DefaultAirBulletScale/5.7f * (1f/i)));
           
            airBullet.transform.localScale = Vector2.one * currentAirBulletScale;
            yield return new WaitForSeconds(shrinkTime / shrinkFrames);
        }
        

    }
    IEnumerator DeactivateBullets()
    {
        //Want the bullets to deactivate no matter what after a certain amount of time to limit range etc. SetActive
        //Doesn't have a method for this.
        yield return new WaitForSeconds(1.0f);
        airBullet.SetActive(false);
    }
}
