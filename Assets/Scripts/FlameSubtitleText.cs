using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSubtitleText : MonoBehaviour
{
   public CapsuleCollider2D capsuleCollider;
    public FireActivator fireActivator;
    public bool switchFlipped;
    public Animator animator;

    void Start()
    {
        fireActivator = FindObjectOfType<FireActivator>();
        capsuleCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(fireActivator == null)
        {
            capsuleCollider.enabled = true;
            animator.SetBool("switchFlipped", true);
        }
        else
        { 
                
        }
    }
}
