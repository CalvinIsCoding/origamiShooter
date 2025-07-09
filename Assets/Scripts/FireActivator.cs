using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    public FireMode fireMode;
    public Collider2D outsideCollider;
    public Animator animator;
    public AudioSource SwitchSound;
    public AudioClip[] switchClicks = new AudioClip[3];
    public GameStatsScript gameStats;

    public CircleCollider2D fireActivatorCollider;
    //public FireActivator fireActivator;
    void Start()
    {
        fireMode = FindObjectOfType<FireMode>();
       
    }

    // Update is called once per frame
    void Update()
    {
            }
    private void OnTriggerEnter2D(Collider2D outsideCollider)
    {
        PlayerController player = outsideCollider.GetComponent<PlayerController>();
        if (player != null)
        {
            fireMode.activatorCounter++;
            animator.SetBool("SwitchActivated", true);
            fireActivatorCollider.enabled = false;

            SwitchSound = player.FanSoundFX;
            SwitchSound.pitch = 0.9f + (0.05f * gameStats.wavesSurvived);
            SwitchSound.PlayOneShot(switchClicks[fireMode.activatorCounter - 1]);


            Destroy(gameObject,0.550f);

           

        }
    }
}
