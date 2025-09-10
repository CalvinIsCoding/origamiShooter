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

    public AudioSource flameAudio;
    public AudioClip[] flameErupt = new AudioClip[4];
    private int soundSelect;
    private float timeSinceLastSound;
    private float soundWaitTime;
    public GameStatsScript gameStats;
    SpriteRenderer[] flameAnimationSprites;

    public GameSettings gameSettings;


    // public PlayerInventory playerInventory;

    void Start()
    {
        //Destroy(firePlace, explosionTime);
        //Border.instance.DestroyBorder(transform.position, radius);
        fireCollider.enabled = true;
        flameAnimations.SetActive(false);
        soundWaitTime = 0.01f;
        flameAnimationSprites = flameAnimations.GetComponentsInChildren<SpriteRenderer>(true);

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
        if (enemySpawn.wave[enemySpawn.waveNumber].bossWave == true)
        {
            int i = 0;
            foreach (SpriteRenderer child in flameAnimationSprites)
            {
                
                flameAnimationSprites[i].color = new Color(0f, 0.9f, 0.9f,1f);
                i++;
            }
            
        }

        timeSinceLastSound = timeSinceLastSound + Time.deltaTime;

        flameAudio.volume = gameSettings.sfxVolume;

    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        PlayerController player = collision.GetComponent<PlayerController>();
        BoxFan boxfan = collision.GetComponent<BoxFan>();
        Boss boss = collision.GetComponent<Boss>();

        // Border border = collision.GetComponent<Border>();
        // Tilemap tilemap = GetComponent<Tilemap>();


        if (enemy != null && fireMode.isFireMode)
        {

            //enemy.Die();

            //For Now just for testing purposes


            //Debug.Log("enemy touching fireplace");
            processSound();
            enemy.TakeDamage(10);

        }
        if(boss != null && boss.isInvulnerable == false )
        {

            boss.TakeDamage(10);
            StartCoroutine(boss.bossBecomesVulnerable());
            if (boss.health > 0)
            {
                StartCoroutine(boxfan.TurnSpriteRed());
            }
            
        }
        if(player!= null && fireMode.isFireMode)
        {
            player.PlayerDeath();
           // player.Boost(collision);
        }
       

        /*if (border != null)
        {
            Border.instance.DestroyBorder(transform.position, radius);
        }*/


    }
    


   private void OnTriggerStay2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        BoxFan boxfan = collision.GetComponent<BoxFan>();
        if (enemy != null && fireMode.isFireMode)
        {
            processSound();
            enemy.TakeDamage(10);


        }
        if ( boxfan != null)
        {
            //StartCoroutine(boxfan.TurnSpriteRed());
        }
    }
    private void processSound()
    {

        soundSelect = Random.Range(0, flameErupt.Length - 1);

        if (timeSinceLastSound >= soundWaitTime)
        {

            flameAudio.volume = 3f;
            
            flameAudio.PlayOneShot(flameErupt[soundSelect]);


            flameAudio.pitch = ((float)gameStats.enemiesKilledThisWave / (float)gameStats.enemiesSpawnedThisWave) + 0.5f;
            


            timeSinceLastSound = 0f;

        }
    }

}
