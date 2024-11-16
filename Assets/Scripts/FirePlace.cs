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
    public SpriteRenderer fireHitBox;

    public EnemySpawn enemySpawn;
    public GameObject flameAnimations;
    
    
   // public PlayerInventory playerInventory;

    void Start()
    {
        //Destroy(firePlace, explosionTime);
        //Border.instance.DestroyBorder(transform.position, radius);
        fireCollider.enabled = true;
        flameAnimations.SetActive(false);


        //StartCoroutine(EnableFireMode());
    }
    private void Update()
    {
        if(fireMode.isFireMode)
        {
            //fireHitBox.color = Color.red;
            flameAnimations.SetActive(true);
        }
        else
        {
            //fireHitBox.color = Color.clear;
            flameAnimations.SetActive(false);
        }
        

        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        PlayerController player = collision.GetComponent<PlayerController>();

        // Border border = collision.GetComponent<Border>();
        // Tilemap tilemap = GetComponent<Tilemap>();


        if (enemy != null && fireMode.isFireMode)
        {

            //enemy.Die();

            //For Now just for testing purposes
            enemy.TakeDamage(10);


        }
        if(player!= null)
        {
            //player.PlayerDeath();
            player.Boost(collision);
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
