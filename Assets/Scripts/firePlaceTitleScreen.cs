using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePlaceTitleScreen : MonoBehaviour
{
    private int soundSelect;
    private float timeSinceLastSound;
    private float soundWaitTime;
    public AudioSource flameAudio;
    public AudioClip[] flameErupt = new AudioClip[4];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        PlayerController player = collision.GetComponent<PlayerController>();
        BoxFan boxfan = collision.GetComponent<BoxFan>();
        Boss boss = collision.GetComponent<Boss>();

        // Border border = collision.GetComponent<Border>();
        // Tilemap tilemap = GetComponent<Tilemap>();


        if (enemy != null)
        {

            //enemy.Die();

            //For Now just for testing purposes


            //Debug.Log("enemy touching fireplace");
            processSound();
            enemy.TakeDamage(10);

        }
        if (boss != null && boss.isInvulnerable == false)
        {

            boss.TakeDamage(10);
            StartCoroutine(boss.bossBecomesVulnerable());
            if (boss.health > 0)
            {
                StartCoroutine(boxfan.TurnSpriteRed());
            }

        }
        if (player != null)
        {
            player.PlayerDeath();
            // player.Boost(collision);
        }


        /*if (border != null)
        {
            Border.instance.DestroyBorder(transform.position, radius);
        }*/


    }
    private void processSound()
    {

        soundSelect = Random.Range(0, flameErupt.Length - 1);

        if (timeSinceLastSound >= soundWaitTime)
        {

            flameAudio.volume = 3f;

            flameAudio.PlayOneShot(flameErupt[soundSelect]);


            



            timeSinceLastSound = 0f;

        }
    }

}
