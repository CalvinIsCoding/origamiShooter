using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource wallAudio;
    public AudioClip[] pageFlip = new AudioClip[7];
    public AudioClip bassDrum;
    public AudioClip closedHiHat;

    private float timeSinceLastSnare;
    private float timeSinceLastBassDrum;
    private float timeSinceLastHiHat;
    private float timeSinceLastSound;
    private float soundWaitTime;

    private int collisionCount;
    private int soundSelect;


    void Start()
    {
        soundWaitTime = 0.01f;
        collisionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSnare = timeSinceLastSnare + Time.deltaTime;
        timeSinceLastBassDrum = timeSinceLastBassDrum + Time.deltaTime;
        timeSinceLastHiHat = timeSinceLastHiHat + Time.deltaTime;
        timeSinceLastSound = timeSinceLastSound + Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        /*
        if (enemy != null && collision.relativeVelocity.magnitude > 4 && timeSinceLastSnare >= soundWaitTime)
        {
            wallAudio.PlayOneShot(snare);
            timeSinceLastSnare = 0f;
            
        }
        else if (enemy != null && collision.relativeVelocity.magnitude < 4 && collision.relativeVelocity.magnitude > 2 && timeSinceLastBassDrum >= soundWaitTime)
        {
            wallAudio.PlayOneShot(bassDrum);
            timeSinceLastBassDrum = 0f;
        }
        else if (enemy != null && collision.relativeVelocity.magnitude < 2 && timeSinceLastHiHat >= soundWaitTime)
        {
            wallAudio.PlayOneShot(closedHiHat);
            timeSinceLastHiHat = 0f;
        }
        */
        soundSelect = Random.Range(0, 6);
        if (timeSinceLastSound >= soundWaitTime)
        {

            if (enemy != null )
            {
                wallAudio.PlayOneShot(pageFlip[soundSelect]);
                timeSinceLastSnare = 0f;
                collisionCount++;
                wallAudio.pitch = Random.Range(0.75f, 1.25f);

            }
       
            timeSinceLastSound = 0f;
           
        }

    }
}
