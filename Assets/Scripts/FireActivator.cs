using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    public FireMode fireMode;
    public Collider2D collision;
    public Animator animator;
    public AudioSource SwitchSounds;
    //public FireActivator fireActivator;
    void Start()
    {
        fireMode = FindObjectOfType<FireMode>();
    }

    // Update is called once per frame
    void Update()
    {
            }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            fireMode.activatorCounter++;
            animator.SetBool("SwitchActivated", true);
            //collision.enabled = false;
            SwitchSounds.Play();
            Destroy(gameObject,0.550f);

           

        }
    }
}
