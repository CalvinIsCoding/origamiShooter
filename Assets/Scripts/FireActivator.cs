using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    public FireMode fireMode;
    public Collider2D outsideCollider;
    public Animator animator;
    public AudioSource SwitchSounds;
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
            SwitchSounds.Play();
            Destroy(gameObject,0.550f);

           

        }
    }
}
