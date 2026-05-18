using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject fireBullet;

    public Rigidbody2D rb;
    public float speed;
    public GameObject bulletEnemy;
    public GameObject source;
    public int bulletDamage = 100;
    public float knockBack = 0.8f;
    public ShopItemSO fanBlades;
    public ShopItemSO biggerfire;

    public SpriteRenderer fireBulletSprite;

    //shrink bullets
    private int shrinkFrames = 30;
    private float DefaultfireBulletScale;
    private float currentfireBulletScale;
    private float shrinkTime;
   
    void OnEnable()
    {

        rb.linearVelocity = transform.right * speed;
        //Destroy(fireBullet, 1.0f);
        //Object Pooling

        knockBack = 15f + (fanBlades.numberPurchased * fanBlades.modifier);
        shrinkTime = 0.5f;
        DefaultfireBulletScale = 0.4f + (biggerfire.numberPurchased * biggerfire.modifier);
        currentfireBulletScale = DefaultfireBulletScale;
        StartCoroutine(ShrinkBullets());
        StartCoroutine(DeactivateBullets());
    }
    private void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        FireBullet collidedBullet = collision.GetComponent<FireBullet>();
        Boss boss = collision.GetComponent<Boss>();

        if (myWall != null)
        {
            //Instantiate(source, fireBullet.transform.position, fireBullet.transform.rotation);
            //Destroy(collidedBullet);
            //Object pooling bullet. Send back to cache
            //fireBullet.SetActive(false);
            //fireBulletSprite.enabled = false;
        }

        
        else if (enemy != null  )
        {
            // 
            enemy.TakeDamage(1);
            //fireBullet.SetActive(false);
            // Destroy(fireBullet);

        }
        if ( boss != null )
        {
            boss.TakeDamage(1);
        }
        
        if (enemyProjectile != null)
        {
            //Destroy(fireBullet);
            fireBullet.SetActive(false);
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
        FireBullet collidedBullet = collision.GetComponent<FireBullet>();
        Boss boss = collision.GetComponent<Boss>();

        if (myWall != null)
        {
            //Instantiate(source, fireBullet.transform.position, fireBullet.transform.rotation);
            //Destroy(bullet);
            //fireBullet.SetActive(false);
            //fireBulletSprite.enabled = false;
        }


        else if (enemy != null)
        {
            // 
            enemy.TakeDamage(1);
            //Destroy(fireBullet);

        }
        if (boss != null)
        {
            boss.TakeDamage(1);
        }

        if (enemyProjectile != null)
        {
            //Destroy(fireBullet);
            fireBullet.SetActive(false);
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
            currentfireBulletScale -= ((DefaultfireBulletScale/5.7f * (1f/i)));
           
            fireBullet.transform.localScale = Vector2.one * currentfireBulletScale;
            yield return new WaitForSeconds(shrinkTime / shrinkFrames);
        }
        

    }
    IEnumerator DeactivateBullets()
    {
        //Want the bullets to deactivate no matter what after a certain amount of time to limit range etc. SetActive
        //Doesn't have a method for this.
        yield return new WaitForSeconds(0.8f);
        fireBullet.SetActive(false);
    }
}
