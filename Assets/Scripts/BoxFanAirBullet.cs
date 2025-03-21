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
    public float knockBack;

    public SpriteRenderer boxFanAirBulletSprite;

    //shrink bullets
    private int shrinkFrames = 30;
    private float currentScale;
    private float shrinkTime;
    void Start()
    {
        knockBack = 25f;
        rb.velocity = transform.right * speed;
        Destroy(boxFanAirBullet, 1.0f);
        shrinkTime = 0.5f;
        currentScale = 0.2f;
        StartCoroutine(ShrinkBullets());
    }
    private void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Wall myWall = collision.GetComponent<Wall>();
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.GetComponent<EnemyProjectile>();
        //BoxFanAirBullet collidedBullet = collision.GetComponent<BoxFanAirBullet>();
        PlayerController playerController = collision.GetComponent<PlayerController>();
        BoxFan boxFan = collision.GetComponent<BoxFan>();

        if (myWall != null)
        {
            Instantiate(source, boxFanAirBullet.transform.position, boxFanAirBullet.transform.rotation);
            //Destroy(bullet);
            boxFanAirBulletSprite.enabled = false;
        }

        
        else if (enemy != null && boxFan == null)
        {
            // 
            enemy.Push(knockBack / 2f,rb,boxFanAirBullet, rb.velocity);
            Destroy(boxFanAirBullet);

        }

        else if (playerController != null)
        {
            playerController.Push(knockBack / 1.5f,rb,boxFanAirBullet );
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
    IEnumerator ShrinkBullets()
    {
        float scaleAtStart = currentScale;
        float knockBackAtStart = knockBack;
        for (int i = 1; i < shrinkFrames; i++)
        {
            currentScale -= ((scaleAtStart * (1f / shrinkFrames)));
            //Knock back needs to drop off more slowly at the beginning so that a reasonable knockback value can be set
            knockBack = 25f - (3f * Mathf.Pow((shrinkTime * i/shrinkFrames),2));
            boxFanAirBullet.transform.localScale = Vector2.one * currentScale;
            yield return new WaitForSeconds(shrinkTime / shrinkFrames);
        }


    }
}
