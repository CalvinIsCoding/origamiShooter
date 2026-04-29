using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    public FireMode fireMode;
    public Collider2D outsideCollider;
    public Animator animator;
    public AudioSource SwitchSound;
    public AudioClip[] switchClicks = new AudioClip[4];
    public GameStatsScript gameStats;
    public Transform player;
    public Rigidbody2D rb;
    public Vector2 directionTowardsPlayer;
    public float activatorForce;
    public GameObject airBurst;

    public CircleCollider2D fireActivatorCollider;
    //public FireActivator fireActivator;

    public ShopItemSO fireSwitchMagnet;
    public ShopItemSO fireSwitchMover;
    public ShopItemSO fireSwitchAirBurst;
    void Start()
    {
        fireMode = FindAnyObjectByType<FireMode>();
        player = FindAnyObjectByType<PlayerController>().transform;
        rb.linearDamping = Random.Range(0.25f, 0.5f);
        activatorForce = Random.Range(0.1f, 0.2f);
       // Debug.Log("damping" + rb.linearDamping);
       // Debug.Log("force" + activatorForce);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void FixedUpdate()
    {
        if (fireSwitchMagnet.numberPurchased > 0)
        {
            attractToPlayer();
        }

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
            if (fireSwitchAirBurst.numberPurchased > 0)
            {
                Instantiate(airBurst,this.transform.position,Quaternion.identity);
            }

        }
    }
    void attractToPlayer()
    {
        directionTowardsPlayer = player.position - this.transform.position;
        rb.AddForce(directionTowardsPlayer.normalized * activatorForce);
    }
}
