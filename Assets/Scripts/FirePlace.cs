using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour
{
    //public GameObject firePlace;
    public int bulletDamage = 101;
    public int radius = 10;
    private float timeTillFire;
    public float fireModeTime;
    public FireMode fireMode;
    public CapsuleCollider2D fireCollider;
    public SpriteRenderer fireSprite;

    public EnemySpawn enemySpawn;

    void Start()
    {
        //Destroy(firePlace, explosionTime);
        //Border.instance.DestroyBorder(transform.position, radius);
        fireCollider.enabled = true;
        
        //StartCoroutine(EnableFireMode());
    }
    private void Update()
    {
        if(fireMode.isFireMode)
        {
            fireSprite.color = Color.red;
        }
        else
        {
            fireSprite.color = Color.white;
        }
        

        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        playerController player = collision.GetComponent<playerController>();

        // Border border = collision.GetComponent<Border>();
        // Tilemap tilemap = GetComponent<Tilemap>();


        if (enemy != null && fireMode.isFireMode)
        {

            enemy.Die();


        }
        if(player!= null)
        {
            player.PlayerDeath();
        }

        /*if (border != null)
        {
            Border.instance.DestroyBorder(transform.position, radius);
        }*/


    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null && fireMode.isFireMode)
        {

            enemy.Die();


        }
    }
    
}
